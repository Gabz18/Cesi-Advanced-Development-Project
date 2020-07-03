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
   
    public class ServiceJavaReceiver : IServiceJavaReceiver
    {

       public void correctCodeFound(MSG msg)
        {
            string textGuid = msg.PropRand;
            string decryptionCode = msg.DecryptionCode;
            string secretInformation = new UTF8Encoding().GetString(msg.SecretInformation);

            

            Thread ResultFound = new Thread(() =>
            {
                DecryptorManagerContainer decryptorManagerContainer = DecryptorManagerContainer.Instance;
                DecryptorManager decryptorManager = DecryptorManagerContainer.Instance.GetDecryptorManager(textGuid);

                decryptorManager.CorrectKeyFound(decryptionCode, secretInformation);
            });

            ResultFound.Start();

            Console.WriteLine("Bon code trouvé pour {0}, secret info: {1} et code: {2}", textGuid, secretInformation, decryptionCode);
        }
        
    }
}
