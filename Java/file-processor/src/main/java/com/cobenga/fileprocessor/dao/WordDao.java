package com.cobenga.fileprocessor.dao;

import javax.ejb.Local;

@Local
public interface WordDao {

    boolean wordExists(String word);
}
