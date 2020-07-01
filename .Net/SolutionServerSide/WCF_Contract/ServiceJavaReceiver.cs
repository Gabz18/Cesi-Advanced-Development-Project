using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_Contract
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceJavaReceiver" à la fois dans le code et le fichier de configuration.
    public class ServiceJavaReceiver : IServiceJavaReceiver
    {

       public void correctCodeFound(MSG msg)
        {
            MSG message = msg;
            string textGuid = msg.PropRand;
            string decryptionCode = msg.DecryptionCode;
            UTF8Encoding utf8 = new UTF8Encoding();

            string secretInformation = utf8.GetString(msg.SecretInformation);

            

            Thread ResultFound = new Thread(() =>
            {
                DecryptorManagerContainer decryptorManagerContainer = DecryptorManagerContainer.Instance;
                DecryptorManager decryptorManager = DecryptorManagerContainer.Instance.GetDecryptorManager(textGuid);

                decryptorManager.CorrectKeyFound(decryptionCode, secretInformation);
            });

            ResultFound.Start();

            Console.WriteLine(msg.TextGuid);

            Console.WriteLine("Bon code trouvé pour {0}, secret info: {1} et code: {2}", textGuid, secretInformation, decryptionCode);
        }
        
    }
}
