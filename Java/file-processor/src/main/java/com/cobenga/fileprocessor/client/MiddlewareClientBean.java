package com.cobenga.fileprocessor.client;

import javax.ejb.Stateless;

@Stateless
public class MiddlewareClientBean implements MiddlewareClient {

    @Override
    public void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String documentName) {

    }
}
