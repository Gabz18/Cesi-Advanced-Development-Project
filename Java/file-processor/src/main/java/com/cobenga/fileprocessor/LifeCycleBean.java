package com.cobenga.fileprocessor;

import com.cobenga.fileprocessor.client.MiddlewareClient;
import com.cobenga.fileprocessor.dao.WordDao;
import com.cobenga.fileprocessor.dao.WordDaoImpl;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.ejb.Singleton;
import javax.ejb.Startup;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;

@Singleton
@Startup
public class LifeCycleBean {

    private static final String PATH_TO_DICTIONARY =
            "C:/Users/gabin/Desktop/Cesi-Advanced-Development-Project/Java/file-processor/src/main/resources/dictionary.txt";

    @EJB
    private WordDao wordDao;

    //@EJB
    //private MiddlewareClient tester;

    @PostConstruct
    public void init() {
        //tester.notifyMiddlewareSecretInformationHasBeenFound("Benjamin", "Rebattu", "Marche chien");
        wordDao.reInitDb();
        File file = new File(PATH_TO_DICTIONARY);
        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = br.readLine()) != null) {
                wordDao.insertWord(line);
            }
        } catch (Exception e) {
            Logger.getLogger(LifeCycleBean.class.getName()).log(Level.SEVERE, null, e);
        }
    }
}
