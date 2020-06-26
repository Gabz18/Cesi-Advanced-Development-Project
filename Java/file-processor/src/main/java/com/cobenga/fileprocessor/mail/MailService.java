package com.cobenga.fileprocessor.mail;

import org.apache.commons.mail.EmailException;

import javax.ejb.Local;

@Local
public interface MailService {

    void sendMail(String to, String subject, String message) throws EmailException;
}
