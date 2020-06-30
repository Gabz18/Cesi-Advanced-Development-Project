package com.cobenga.fileprocessor.client;

import com.cobenga.fileprocessor.client.generated.FileEndpoint;
import com.cobenga.fileprocessor.client.generated.FileService;

import javax.ejb.Stateless;
import javax.xml.ws.WebServiceRef;

/**
 * @author Gabz18
 */
@Stateless
public class MiddlewareClientBean implements MiddlewareClient {


    @WebServiceRef(FileService.class)
    private FileEndpoint fileEndpoint;

    /**
     * {@inheritDoc}
     */
    @Override
    public void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String fileUuid) {
        fileEndpoint.fileAnalysisProcessStart("a", "a", "a", "a", "a");
    }
}
