package com.cobenga.fileprocessor.client;

import com.cobenga.fileprocessor.client.generated.IServiceJavaReceiver;
import com.cobenga.fileprocessor.client.generated.MSG;
import com.cobenga.fileprocessor.client.generated.ObjectFactory;
import com.cobenga.fileprocessor.client.generated.ServiceJavaReceiver;

import javax.ejb.Stateless;
import javax.xml.ws.WebServiceRef;

/**
 * @author Gabz18
 */
@Stateless
public class MiddlewareClientBean implements MiddlewareClient {

    private final ObjectFactory factory = new ObjectFactory();

    @WebServiceRef(ServiceJavaReceiver.class)
    private IServiceJavaReceiver serviceJavaReceiver;

    /**
     * {@inheritDoc}
     */
    @Override
    public void notifyMiddlewareSecretInformationHasBeenFound(String secretInformation, String code, String fileUuid) {
        MSG message = new MSG();
        message.setSecretInformation(factory.createMSGSecretInformation(secretInformation.getBytes()));
        message.setDecryptionCode(factory.createMSGDecryptionCode(code));
        message.setTextGuid(factory.createGuid(fileUuid));
        message.setPropRand(factory.createMSGPropRand(fileUuid));
        serviceJavaReceiver.correctCodeFound(message);
    }
}
