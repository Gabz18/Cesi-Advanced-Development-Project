package com.cobenga.fileprocessor;

import javax.annotation.PostConstruct;
import javax.ejb.Singleton;
import javax.ejb.Startup;

@Singleton
@Startup
public class LifeCycleBean {

    @PostConstruct
    public void init() {
        // TODO fill database
    }
}
