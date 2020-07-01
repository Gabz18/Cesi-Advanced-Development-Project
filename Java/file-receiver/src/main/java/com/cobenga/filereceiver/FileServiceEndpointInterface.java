package com.cobenga.filereceiver;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
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
     */
    @WebMethod(operationName = "fileAnalysisProcessStart")
    @WebResult(name = "FileProcessingStarted")
    Boolean handleIncomingFile(
            @WebParam(name = "fileName") String fileName,
            @WebParam(name = "FileInternalUUID") String fileUuid,
            @WebParam(name = "code") String code,
            @WebParam(name = "decryptedText") String decryptedText,
            @WebParam(name = "userEmail") String userEmail
    );
}
