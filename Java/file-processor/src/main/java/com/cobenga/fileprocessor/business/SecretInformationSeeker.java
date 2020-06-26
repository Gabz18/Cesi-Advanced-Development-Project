package com.cobenga.fileprocessor.business;

import javax.ejb.Local;

@Local
public interface SecretInformationSeeker {

    String findSecretInformation(String text);
}
