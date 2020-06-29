using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService2" à la fois dans le code et le fichier de configuration.
    [ServiceContract(CallbackContract = typeof(IPushCallback))]
    public interface IService2
    {
        [OperationContract(IsOneWay = true)]
        void verifyData(string code);
    }
}
