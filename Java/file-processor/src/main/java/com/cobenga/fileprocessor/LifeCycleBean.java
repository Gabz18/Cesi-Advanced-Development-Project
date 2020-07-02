package com.cobenga.fileprocessor;

import com.cobenga.fileprocessor.business.DecryptedFileAnalyzer;
import com.cobenga.fileprocessor.business.SecretInformationSeeker;
import com.cobenga.fileprocessor.client.MiddlewareClient;
import com.cobenga.fileprocessor.dao.WordDao;
import com.cobenga.fileprocessor.dao.WordDaoImpl;
import com.cobenga.fileprocessor.mail.MailService;
import org.apache.commons.mail.EmailException;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.ejb.Singleton;
import javax.ejb.Startup;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.TextMessage;
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

    @EJB
    private DecryptedFileAnalyzer decryptedFileAnalyzer;

    @EJB
    private SecretInformationSeeker secretInformationSeeker;

    @EJB
    private MailService mailService;

    @EJB
    private ProcessedFilesUuidCache uuidsCache;

    @EJB
    private MiddlewareClient tester;

    @PostConstruct
    public void init() {
        //System.out.println(decryptedFileAnalyzer.findTextValidityConfidence("/;:4=16baeg&.%"));

        //tester.notifyMiddlewareSecretInformationHasBeenFound("Benjamin", "Rebattu", "Marche chien");
        /*
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

        System.out.println("-------------------- Message received ------------------------");
        try {
            String fileUuid = "A1234";
            if (uuidsCache.hasFileAlreadyBeenProcessed(fileUuid)) {
                return;
            }
            String messageBody = "Ceci est un fichier chiffré top secret. Gabin est beau. Ben est super sympa (et beau). L'information secrète est : Ce projet date de 2008. Fin de transmission.";
            String code = "AAAA";
            String fileName = "fichier.txt";
            String userEmail = "gabinritz@gmail.com";

            if (decryptedFileAnalyzer.findTextValidityConfidence(messageBody) >= 0.5d) {

                uuidsCache.addProcessedFileUuid(fileUuid);

                String secretInfo = secretInformationSeeker.findSecretInformation(messageBody);

                System.out.println("Secret information found : " + secretInfo);

                mailService.sendMail(userEmail, "SUJET", buildMailBody(fileName, code, secretInfo));
            }
        } catch (EmailException e) {
            e.printStackTrace();
        }

         */

    }

    private String buildMailBody(String fileName, String code, String secretInfo) {
        return "File : " +
                fileName +
                "\n\n" +
                "Secret Code : " +
                code +
                "\n\n" +
                "Secret Information : " +
                secretInfo;
    }
}
