package com.cobenga.fileprocessor.mail;

import org.apache.commons.mail.Email;
import org.apache.commons.mail.EmailException;
import org.apache.commons.mail.SimpleEmail;

import javax.ejb.Stateless;

@Stateless
public class MailServiceBean implements MailService {

    private static final String SMTP_HOST = "localhost";
    private static final int SMTP_PORT = 8082;
    private static final String MAIl_FROM = "Encrypted File Processor";

    @Override
    public void sendMail(String to, String subject, String message) throws EmailException {
        Email email = new SimpleEmail();
        email.setHostName(SMTP_HOST);
        email.setSmtpPort(SMTP_PORT);
        email.setFrom(MAIl_FROM);
        email.addTo(to);
        email.setSubject(subject);
        email.setMsg(message);
        email.send();
    }
}
