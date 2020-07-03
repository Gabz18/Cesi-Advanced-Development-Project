using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]

    public interface IService1
    {
        [OperationContract]
        STG m_service(STG msg);

    }


    [DataContract]
    public class STG
    {
        bool statutOP;
        string info;
        object[] data;
        string operationName;
        string tokenApp;
        string tokenUser;
        string appVersion;
        string operationVersion;

        [DataMember]
        public bool StatutOP { get => statutOP; set => statutOP = value; }
        
        [DataMember]
        public string Info { get => info; set => info = value; }

        [DataMember]
        public object[] Data { get => data; set => data = value; }

        [DataMember]
        public string OperationName { get => operationName; set => operationName = value; }
        
        [DataMember]
        public string TokenApp { get => tokenApp; set => tokenApp = value; }
        
        [DataMember]
        public string TokenUser { get => tokenUser; set => tokenUser = value; }
        
        [DataMember]
        public string AppVersion { get => appVersion; set => appVersion = value; }
        
        [DataMember]
        public string OperationVersion { get => operationVersion; set => operationVersion = value; }
    }
}
