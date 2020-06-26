package com.cobenga.fileprocessor.mail;

import org.apache.commons.mail.EmailException;

import javax.ejb.Local;

/**
 * @author Gabz18
 */
@Local
public interface MailService {

    /**
     * Sends a mail to a target email address.
     *
     * @param to The email recipient.
     * @param subject The email subject.
     * @param message The email message body.
     * @throws EmailException
     */
    void sendMail(String to, String subject, String message) throws EmailException;
}
