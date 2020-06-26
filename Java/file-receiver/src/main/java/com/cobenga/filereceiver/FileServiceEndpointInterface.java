package com.cobenga.filereceiver;

import javax.jms.JMSException;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

@WebService(name = "FileEndpoint")
public interface FileServiceEndpointInterface {

    @WebMethod(operationName = "fileAnalysisProcessStart")
    void handleIncomingFile(
            @WebParam(name = "fileName") String fileName,
            @WebParam(name = "code") String code,
            @WebParam(name = "decryptedText") String decryptedText,
            @WebParam(name = "userEmail") String userEmail
    ) throws JMSException;
}
