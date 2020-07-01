using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceJavaReceiver" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceJavaReceiver
    {
        [OperationContract]
        void correctCodeFound(MSG msg);
    }

    [DataContract]
    public class MSG
    {
        byte[] secretInformation;
        string decryptionCode;
        string textGuid;
        string propRand;

        [DataMember]
        public byte[] SecretInformation { get => secretInformation; set => secretInformation = value; }

        [DataMember]
        public string PropRand { get => propRand; set => propRand = value; }

        [DataMember]
        public string DecryptionCode { get => decryptionCode; set => decryptionCode = value; }

        [DataMember]
        public string TextGuid { get => textGuid; set => textGuid = value; }
    } 
}
