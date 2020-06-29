using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service2" à la fois dans le code et le fichier de configuration.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Service2 : IService2
    {
        public void verifyData(string code)
        {
            Console.WriteLine("Je fais ce qu'on me dit");
        }
    }
}
