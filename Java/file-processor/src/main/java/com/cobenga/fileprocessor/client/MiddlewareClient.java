package com.cobenga.fileprocessor.client;

import javax.ejb.Local;

@Local
public interface MiddlewareClient {

    void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String documentName);
}
