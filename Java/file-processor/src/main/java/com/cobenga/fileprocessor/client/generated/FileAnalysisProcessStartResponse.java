
package com.cobenga.fileprocessor.client.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour fileAnalysisProcessStartResponse complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="fileAnalysisProcessStartResponse">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="FileProcessingStarted" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "fileAnalysisProcessStartResponse", propOrder = {
    "fileProcessingStarted"
})
public class FileAnalysisProcessStartResponse {

    @XmlElement(name = "FileProcessingStarted")
    protected Boolean fileProcessingStarted;

    /**
     * Obtient la valeur de la propriété fileProcessingStarted.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isFileProcessingStarted() {
        return fileProcessingStarted;
    }

    /**
     * Définit la valeur de la propriété fileProcessingStarted.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setFileProcessingStarted(Boolean value) {
        this.fileProcessingStarted = value;
    }

}
