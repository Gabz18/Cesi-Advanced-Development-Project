
package com.cobenga.fileprocessor.client.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour fileAnalysisProcessStart complex type.
 * 
 * <p>Le fragment de sch�ma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="fileAnalysisProcessStart">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="fileName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="File internal UUID" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="code" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="decryptedText" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="userEmail" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "fileAnalysisProcessStart", propOrder = {
    "fileName",
    "file0020Internal0020UUID",
    "code",
    "decryptedText",
    "userEmail"
})
public class FileAnalysisProcessStart {

    protected String fileName;
    @XmlElement(name = "File internal UUID")
    protected String file0020Internal0020UUID;
    protected String code;
    protected String decryptedText;
    protected String userEmail;

    /**
     * Obtient la valeur de la propri�t� fileName.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getFileName() {
        return fileName;
    }

    /**
     * D�finit la valeur de la propri�t� fileName.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFileName(String value) {
        this.fileName = value;
    }

    /**
     * Obtient la valeur de la propri�t� file0020Internal0020UUID.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getFile_0020Internal_0020UUID() {
        return file0020Internal0020UUID;
    }

    /**
     * D�finit la valeur de la propri�t� file0020Internal0020UUID.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFile_0020Internal_0020UUID(String value) {
        this.file0020Internal0020UUID = value;
    }

    /**
     * Obtient la valeur de la propri�t� code.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCode() {
        return code;
    }

    /**
     * D�finit la valeur de la propri�t� code.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCode(String value) {
        this.code = value;
    }

    /**
     * Obtient la valeur de la propri�t� decryptedText.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDecryptedText() {
        return decryptedText;
    }

    /**
     * D�finit la valeur de la propri�t� decryptedText.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDecryptedText(String value) {
        this.decryptedText = value;
    }

    /**
     * Obtient la valeur de la propri�t� userEmail.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUserEmail() {
        return userEmail;
    }

    /**
     * D�finit la valeur de la propri�t� userEmail.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUserEmail(String value) {
        this.userEmail = value;
    }

}
