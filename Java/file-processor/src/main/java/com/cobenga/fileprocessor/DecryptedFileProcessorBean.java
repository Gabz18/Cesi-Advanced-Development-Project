package com.cobenga.fileprocessor;

import com.cobenga.fileprocessor.business.DecryptedFileAnalyzer;
import com.cobenga.fileprocessor.business.SecretInformationSeeker;
import com.cobenga.fileprocessor.client.MiddlewareClient;
import com.cobenga.fileprocessor.mail.MailService;
import org.apache.commons.mail.EmailException;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.EJB;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;

/**
 * @author Gabz18
 */
@MessageDriven(
        activationConfig = {
                @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "jms/decryptedFileQueue"),
                @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
        }
)
public class DecryptedFileProcessorBean implements MessageListener {

    private static final double MIN_CONFIDENCE_LEVEL = 0.9d;
    private static final String MAIL_SUBJECT = "File Analysis Report";

    @EJB
    private DecryptedFileAnalyzer decryptedFileAnalyzer;

    @EJB
    private SecretInformationSeeker secretInformationSeeker;

    @EJB
    private MailService mailService;

    @EJB
    private MiddlewareClient middlewareClient;

    @EJB
    private ProcessedFilesUuidCache uuidsCache;

    /**
     * Processes a JMS message holding a decrypted file and checks whether or not this file contains an sufficient percentage
     * of french words. If so, an email is sent to the user requesting this file processing and a SOAP message is sent to
     * the Information System middleware in order to notify it that the correct decryption code has been found.
     *
     * @param message The JMS {@link javax.jms.TextMessage}.
     */
    @Override
    public void onMessage(Message message) {
        System.out.println("-------------------- Message received ------------------------");
        try {
            String fileUuid = message.getStringProperty("fileUuid");
            if (uuidsCache.hasFileAlreadyBeenProcessed(fileUuid)) {
                return;
            }
            String messageBody = message.getBody(String.class);
            String code = message.getStringProperty("code");
            String fileName = message.getStringProperty("fileName");
            String userEmail = message.getStringProperty("userEmail");

            if (decryptedFileAnalyzer.findTextValidityConfidence(messageBody) >= MIN_CONFIDENCE_LEVEL) {

                uuidsCache.addProcessedFileUuid(fileUuid);

                String secretInfo = secretInformationSeeker.findSecretInformation(messageBody);
                middlewareClient.notifyMiddlewareSecretInformationHasBeenFound(
                        secretInfo,
                        code,
                        fileUuid
                );

                mailService.sendMail(userEmail, MAIL_SUBJECT, buildMailBody(fileName, code, secretInfo));
            }
        } catch (JMSException | EmailException e) {
            e.printStackTrace();
        }
    }

    private String buildMailBody(String fileName, String code, String secretInfo) {
        return "File : " +
                fileName +
                "\n\n" +
                "Secret Code : " +
                code +
                "\n\n" +
                "Secret Information : " +
                secretInfo;
    }
}
