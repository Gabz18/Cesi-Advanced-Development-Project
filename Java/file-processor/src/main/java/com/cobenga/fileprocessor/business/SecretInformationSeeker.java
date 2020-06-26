package com.cobenga.fileprocessor.business;

import javax.ejb.Local;

/**
 * @author Gabz18
 */
@Local
public interface SecretInformationSeeker {

    /**
     * Searches for the string fragment holding the secret information.
     *
     * @param text The text for which the secret information should be found.
     * @return The secret information found.
     */
    String findSecretInformation(String text);
}
