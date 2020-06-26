package com.cobenga.fileprocessor.business;

import javax.ejb.Local;

@Local
public interface DecryptedFileAnalyzer {

    double findTextValidityConfidence(String text);
}
