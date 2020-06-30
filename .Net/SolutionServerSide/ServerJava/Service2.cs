using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerJava
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service2" à la fois dans le code et le fichier de configuration.

    
    public class Service2 : IService2
    {
        public void verifyData(string documentGUID, string code, string resultDecrryption)
        {
            Console.WriteLine("je suis sollicité. Document GUID: {0}, Code: {1}, resultDecryption: {2}", documentGUID, code, resultDecrryption);

            //if(msg.Code == "JVCF")
            //{
            //    Console.WriteLine("j'ai trouvé le bon code");
            //    Sender mySender = Sender.Instance;
            //    mySender.sendToCsMiddleware(msg.DocumentGUID, msg.Code, null);
            //}
        }
    }
}
