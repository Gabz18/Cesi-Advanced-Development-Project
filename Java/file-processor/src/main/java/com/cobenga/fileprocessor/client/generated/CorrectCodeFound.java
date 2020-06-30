
package com.cobenga.fileprocessor.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour anonymous complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="msg" type="{http://schemas.datacontract.org/2004/07/WCF_Contract}MSG" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "msg"
})
@XmlRootElement(name = "correctCodeFound")
public class CorrectCodeFound {

    @XmlElementRef(name = "msg", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<MSG> msg;

    /**
     * Obtient la valeur de la propriété msg.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link MSG }{@code >}
     *     
     */
    public JAXBElement<MSG> getMsg() {
        return msg;
    }

    /**
     * Définit la valeur de la propriété msg.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link MSG }{@code >}
     *     
     */
    public void setMsg(JAXBElement<MSG> value) {
        this.msg = value;
    }

}
