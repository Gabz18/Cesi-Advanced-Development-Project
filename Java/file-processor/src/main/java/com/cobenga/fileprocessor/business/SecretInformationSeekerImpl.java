package com.cobenga.fileprocessor.business;

import javax.ejb.Stateless;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author Gabz18
 */
@Stateless
public class SecretInformationSeekerImpl implements SecretInformationSeeker {

    private final Pattern pattern = Pattern.compile("(L’information secrète est : .*)");

    /**
     * {@inheritDoc}
     */
    @Override
    public String findSecretInformation(String text) {
        Matcher matcher = pattern.matcher(text);
        if (matcher.find()) {
            return matcher.group();
        }
        return "No secret information found";
    }
}
