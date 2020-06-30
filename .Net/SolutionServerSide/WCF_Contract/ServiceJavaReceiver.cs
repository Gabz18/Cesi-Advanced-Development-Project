using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceJavaReceiver" à la fois dans le code et le fichier de configuration.
    public class ServiceJavaReceiver : IServiceJavaReceiver
    {

       public void correctCodeFound(MSG msg)
        {
            MSG message = msg;
            string documentGuid = msg.DocumentGuid;
            string decryptionCode = msg.DecryptionCode;
            string secretInformation = msg.SecretInformation;

            Console.WriteLine(documentGuid);
            Console.WriteLine("le documentGUID est {0}, le code est {1} et l'information secrète est {2}", msg.DocumentGuid, decryptionCode, secretInformation);

            //DecryptorManagerContainer decryptorManagerContainer = DecryptorManagerContainer.Instance;
            //DecryptorManager decryptorManager = DecryptorManagerContainer.Instance.getElementDictionary(documentGUID);

            //decryptorManager.responseReceived(decryptionCode, secretInformation);
        }
        
    }
}
