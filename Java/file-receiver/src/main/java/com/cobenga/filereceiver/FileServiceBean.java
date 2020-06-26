package com.cobenga.filereceiver;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
import javax.jms.TextMessage;
import javax.jws.WebService;

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
    public void handleIncomingFile(String fileName, String fileUuid, String code, String decryptedText, String userEmail) throws JMSException {
        TextMessage textMessage = jmsContext.createTextMessage(decryptedText);
        textMessage.setStringProperty("fileName", fileName);
        textMessage.setStringProperty("code", code);
        textMessage.setStringProperty("userEmail", userEmail);
        textMessage.setStringProperty("fileUuid", fileUuid);
        jmsContext.createProducer().send(decryptedFileQueue, textMessage);
    }
}
