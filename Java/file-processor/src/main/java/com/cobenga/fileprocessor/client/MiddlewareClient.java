package com.cobenga.fileprocessor.client;

import javax.ejb.Local;

/**
 * @author Gabz18
 */
@Local
public interface MiddlewareClient {

    /**
     * Sends a SOAP message to the Information System middleware in order to notify it that the secret information has been
     * found for a given file.
     *
     * @param secretInformation The secret information found.
     * @param code The code used to decrypt the secret information.
     * @param fileUuid The file containing the secret information uuid.
     */
    void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String fileUuid);
}
