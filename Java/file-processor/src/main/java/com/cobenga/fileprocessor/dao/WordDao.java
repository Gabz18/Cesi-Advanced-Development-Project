package com.cobenga.fileprocessor.dao;

import javax.ejb.Local;

/**
 * @author Gabz18
 */
@Local
public interface WordDao {

    /**
     * Checks whether or not a word is present in the database dictionary.
     *
     * @param word The word that should be searched in the dictionary.
     * @return A boolean representing whether or not the word has been found.
     */
    boolean wordExists(String word);

    /**
     * Inserts a new word into the database dictionary.
     *
     * @param word The word to insert.
     * @return True if the word has been inserted.
     */
    boolean insertWord(String word);

    /**
     * Deletes and recreates the database.
     *
     */
    void reInitDb();
}
