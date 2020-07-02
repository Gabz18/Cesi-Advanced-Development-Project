package com.cobenga.filereceiver;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
import javax.jms.TextMessage;
import javax.jws.WebService;
import java.nio.charset.StandardCharsets;

/**
 * @author gabz18
 */
@Stateless
@WebService(
        endpointInterface = "com.cobenga.filereceiver.FileServiceEndpointInterface",
        portName = "FilePort",
        serviceName = "FileService"
)
public class FileServiceBean implements FileServiceEndpointInterface {

    @Inject
    private JMSContext jmsContext;

    @Resource(lookup = "jms/decryptedFileQueue")
    private Queue decryptedFileQueue;

    /**
     * {@inheritDoc}
     */
    @Override
    public Boolean handleIncomingFile(String fileName, String fileUuid, String code, byte[] decryptedText, String userEmail) {
        System.out.println("-------------------- New File message --------------------");
        System.out.println("Text is : " + new String(decryptedText, StandardCharsets.UTF_8));
        TextMessage textMessage = jmsContext.createTextMessage(new String(decryptedText, StandardCharsets.UTF_8));
        try {
            textMessage.setStringProperty("fileName", fileName);
            textMessage.setStringProperty("code", code);
            textMessage.setStringProperty("userEmail", userEmail);
            textMessage.setStringProperty("fileUuid", fileUuid);
            jmsContext.createProducer().send(decryptedFileQueue, textMessage);
            return true;
        } catch (JMSException e) {
            return false;
        }
    }
}
