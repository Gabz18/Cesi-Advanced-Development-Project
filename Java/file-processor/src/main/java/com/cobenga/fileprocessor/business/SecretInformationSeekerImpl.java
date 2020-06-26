package com.cobenga.fileprocessor.business;

import javax.ejb.Stateless;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Stateless
public class SecretInformationSeekerImpl implements SecretInformationSeeker {

    private final Pattern pattern = Pattern.compile("(L’information secrète est : .*)");

    @Override
    public String findSecretInformation(String text) {
        Matcher matcher = pattern.matcher(text);
        if (matcher.find()) {
            return matcher.group();
        }
        return "No secret information found";
    }
}
