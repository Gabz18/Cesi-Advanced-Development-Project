package com.cobenga.fileprocessor.business;

import com.cobenga.fileprocessor.dao.WordDao;

import javax.ejb.EJB;
import javax.ejb.Stateless;

@Stateless
public class DecryptedFileAnalyzerBean implements DecryptedFileAnalyzer {

    private static final int NUMBER_OF_WORDS_CHECKED = 100;

    @EJB
    private WordDao wordDao;

    @Override
    public double findTextValidityConfidence(String text) {
        int i = 0;
        double correctWordsCounter = 0d;
        for (String s : text.split(" ")) {
            if (i > NUMBER_OF_WORDS_CHECKED) {
                break;
            }
            if (wordDao.wordExists(s)) correctWordsCounter++;
            i++;
        }
        return correctWordsCounter / NUMBER_OF_WORDS_CHECKED;
    }
}
