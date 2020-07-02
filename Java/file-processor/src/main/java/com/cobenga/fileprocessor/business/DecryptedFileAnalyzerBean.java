package com.cobenga.fileprocessor.business;

import com.cobenga.fileprocessor.dao.WordDao;

import javax.ejb.EJB;
import javax.ejb.Stateless;

/**
 * @author Gabz18
 */
@Stateless
public class DecryptedFileAnalyzerBean implements DecryptedFileAnalyzer {

    private static final int NUMBER_OF_WORDS_CHECKED = 50;

    @EJB
    private WordDao wordDao;

    /**
     * {@inheritDoc}
     */
    @Override
    public double findTextValidityConfidence(String text) {
        int i = 0;
        double correctWordsCounter = 0d;
        for (String s : text.split("[ ',.;:=+/%&]")) {
            if (i > NUMBER_OF_WORDS_CHECKED) {
                break;
            }
            if (wordDao.wordExists(s.toLowerCase())) correctWordsCounter++;
            i++;
        }
        return correctWordsCounter / i;
    }
}
