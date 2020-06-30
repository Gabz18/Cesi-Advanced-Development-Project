
package com.cobenga.fileprocessor.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour MSG complex type.
 * 
 * <p>Le fragment de sch�ma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="MSG">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="DecryptionCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="DocumentGuid" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="SecretInformation" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "MSG", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", propOrder = {
    "decryptionCode",
    "documentGuid",
    "secretInformation"
})
public class MSG {

    @XmlElementRef(name = "DecryptionCode", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> decryptionCode;
    @XmlElementRef(name = "DocumentGuid", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> documentGuid;
    @XmlElementRef(name = "SecretInformation", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> secretInformation;

    /**
     * Obtient la valeur de la propri�t� decryptionCode.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getDecryptionCode() {
        return decryptionCode;
    }

    /**
     * D�finit la valeur de la propri�t� decryptionCode.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setDecryptionCode(JAXBElement<String> value) {
        this.decryptionCode = value;
    }

    /**
     * Obtient la valeur de la propri�t� documentGuid.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getDocumentGuid() {
        return documentGuid;
    }

    /**
     * D�finit la valeur de la propri�t� documentGuid.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setDocumentGuid(JAXBElement<String> value) {
        this.documentGuid = value;
    }

    /**
     * Obtient la valeur de la propri�t� secretInformation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getSecretInformation() {
        return secretInformation;
    }

    /**
     * D�finit la valeur de la propri�t� secretInformation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setSecretInformation(JAXBElement<String> value) {
        this.secretInformation = value;
    }

}
