
package com.cobenga.fileprocessor.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the com.cobenga.fileprocessor.client.generated package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _FileAnalysisProcessStart_QNAME = new QName("http://filereceiver.cobenga.com/", "fileAnalysisProcessStart");
    private final static QName _FileAnalysisProcessStartResponse_QNAME = new QName("http://filereceiver.cobenga.com/", "fileAnalysisProcessStartResponse");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: com.cobenga.fileprocessor.client.generated
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link FileAnalysisProcessStart }
     * 
     */
    public FileAnalysisProcessStart createFileAnalysisProcessStart() {
        return new FileAnalysisProcessStart();
    }

    /**
     * Create an instance of {@link FileAnalysisProcessStartResponse }
     * 
     */
    public FileAnalysisProcessStartResponse createFileAnalysisProcessStartResponse() {
        return new FileAnalysisProcessStartResponse();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link FileAnalysisProcessStart }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://filereceiver.cobenga.com/", name = "fileAnalysisProcessStart")
    public JAXBElement<FileAnalysisProcessStart> createFileAnalysisProcessStart(FileAnalysisProcessStart value) {
        return new JAXBElement<FileAnalysisProcessStart>(_FileAnalysisProcessStart_QNAME, FileAnalysisProcessStart.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link FileAnalysisProcessStartResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://filereceiver.cobenga.com/", name = "fileAnalysisProcessStartResponse")
    public JAXBElement<FileAnalysisProcessStartResponse> createFileAnalysisProcessStartResponse(FileAnalysisProcessStartResponse value) {
        return new JAXBElement<FileAnalysisProcessStartResponse>(_FileAnalysisProcessStartResponse_QNAME, FileAnalysisProcessStartResponse.class, null, value);
    }

}
