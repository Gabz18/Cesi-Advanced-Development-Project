using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServerJava
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService2" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract(IsOneWay = false)]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        void verifyData(string documentGUID, string code, string resultDecrryption);
    }

    [DataContract]
    public class JavaMessage
    {
        string documentGUID;
        string code;
        string resultDecryption;

        [DataMember]
        public string DocumentGUID { get => documentGUID; set => documentGUID = value; }

        [DataMember]
        public string ResultDecryption { get => resultDecryption; set => resultDecryption = value; }

        [DataMember]
        public string Code { get => code; set => code = value; }
    }
}
