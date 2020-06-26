package com.cobenga.fileprocessor.dao;

import javax.ejb.Stateless;

/**
 * @author Gabz18
 */
@Stateless
public class WordDaoImpl implements WordDao {

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean wordExists(String word) {
        return false;
    }
}
