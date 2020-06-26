package com.cobenga.fileprocessor;

import javax.annotation.Resource;
import javax.ejb.Singleton;
import javax.ejb.Timeout;
import javax.ejb.Timer;
import javax.ejb.TimerService;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Gabz18
 */
@Singleton
public class ProcessedFilesUuidCache {

    private static final int UUID_TIMEOUT = 3600;
    private final List<String> processedFilesUuid = new ArrayList<>();

    @Resource
    private TimerService timerService;


    /**
     * Adds a file UUID to the list of files uuid for which the right decryption code has been found.
     *
     * @param fileUuid The given file uuid.
     */
    public void addProcessedFileUuid(String fileUuid) {
        this.processedFilesUuid.add(fileUuid);
        timerService.createTimer(1000 * UUID_TIMEOUT, fileUuid);
    }

    /**
     * Checks whether or not the correct decryption code has already been found for a given file.
     *
     * @param fileUuid The file uuid to check.
     * @return Whether or not the file code has already been found.
     */
    public boolean hasFileAlreadyBeenProcessed(String fileUuid) {
        return processedFilesUuid.contains(fileUuid);
    }

    /**
     * Frees some storage by removing expired files uuid.
     *
     * @param timer The EJB {@link Timer}.
     */
    @Timeout
    void removeTimedOutUuids(Timer timer) {
        String uuid = (String) timer.getInfo();
        processedFilesUuid.remove(uuid);
    }

}
