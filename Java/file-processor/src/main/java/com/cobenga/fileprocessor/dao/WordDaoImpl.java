package com.cobenga.fileprocessor.dao;

import javax.ejb.Stateless;

@Stateless
public class WordDaoImpl implements WordDao {

    @Override
    public boolean wordExists(String word) {
        return false;
    }
}
