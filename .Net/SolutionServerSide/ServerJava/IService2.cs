using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerJava
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService2" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract(IsOneWay = true)]
        void verifyData(JavaMessage msg);
    }

    [DataContract]
    public class JavaMessage
    {
        string documentGUID;
        string code;
        string resultDecryption;

        [DataMember]
        public string DocumentGUID { get => DocumentGUID; set => DocumentGUID = value; }

        [DataMember]
        public string DocumentDecrypted { get => DocumentDecrypted; set => DocumentDecrypted = value; }

        [DataMember]
        public string Code { get => code; set => code = value; }
    }
}
