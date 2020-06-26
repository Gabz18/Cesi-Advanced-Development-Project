package com.cobenga.fileprocessor.business;

import javax.ejb.Local;

/**
 * @author Gabz18
 */
@Local
public interface DecryptedFileAnalyzer {

    /**
     * Checks whether or not text words are valid french ones.
     *
     * @param text The text to be verified.
     * @return The ratio of valid words met over the number of word analyzed.
     */
    double findTextValidityConfidence(String text);
}
