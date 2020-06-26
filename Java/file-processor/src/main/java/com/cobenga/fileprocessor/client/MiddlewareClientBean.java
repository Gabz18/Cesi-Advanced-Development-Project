package com.cobenga.fileprocessor.client;

import javax.ejb.Stateless;

/**
 * @author Gabz18
 */
@Stateless
public class MiddlewareClientBean implements MiddlewareClient {

    /**
     * {@inheritDoc}
     */
    @Override
    public void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String fileUuid) {

    }
}
