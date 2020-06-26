package com.cobenga.filereceiver;

import javax.jms.JMSException;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 * @author gabz18
 */
@WebService(name = "FileEndpoint")
public interface FileServiceEndpointInterface {

    /**
     * Forwards the incoming file to be processed, to the JMS queue.
     *
     * @param fileName The file name.
     * @param fileUuid The file internal Uuid to the Information System.
     * @param code The decryption code used to obtain this file content.
     * @param decryptedText The decrypted file content.
     * @param userEmail The current asking for this file process.
     * @throws JMSException
     */
    @WebMethod(operationName = "fileAnalysisProcessStart")
    void handleIncomingFile(
            @WebParam(name = "fileName") String fileName,
            @WebParam(name = "File internal UUID") String fileUuid,
            @WebParam(name = "code") String code,
            @WebParam(name = "decryptedText") String decryptedText,
            @WebParam(name = "userEmail") String userEmail
    ) throws JMSException;
}
