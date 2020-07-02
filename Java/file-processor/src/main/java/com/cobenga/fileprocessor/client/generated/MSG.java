
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
 *         &lt;element name="PropRand" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="SecretInformation" type="{http://www.w3.org/2001/XMLSchema}base64Binary" minOccurs="0"/>
 *         &lt;element name="TextGuid" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
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
    "propRand",
    "secretInformation",
    "textGuid"
})
public class MSG {

    @XmlElementRef(name = "DecryptionCode", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> decryptionCode;
    @XmlElementRef(name = "PropRand", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> propRand;
    @XmlElementRef(name = "SecretInformation", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<byte[]> secretInformation;
    @XmlElementRef(name = "TextGuid", namespace = "http://schemas.datacontract.org/2004/07/WCF_Contract", type = JAXBElement.class, required = false)
    protected JAXBElement<String> textGuid;

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
     * Obtient la valeur de la propri�t� propRand.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getPropRand() {
        return propRand;
    }

    /**
     * D�finit la valeur de la propri�t� propRand.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setPropRand(JAXBElement<String> value) {
        this.propRand = value;
    }

    /**
     * Obtient la valeur de la propri�t� secretInformation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link byte[]}{@code >}
     *     
     */
    public JAXBElement<byte[]> getSecretInformation() {
        return secretInformation;
    }

    /**
     * D�finit la valeur de la propri�t� secretInformation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link byte[]}{@code >}
     *     
     */
    public void setSecretInformation(JAXBElement<byte[]> value) {
        this.secretInformation = value;
    }

    /**
     * Obtient la valeur de la propri�t� textGuid.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getTextGuid() {
        return textGuid;
    }

    /**
     * D�finit la valeur de la propri�t� textGuid.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setTextGuid(JAXBElement<String> value) {
        this.textGuid = value;
    }

}
