using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerJava.ServiceReference1;

namespace ServerJava
{
    class Sender
    {
        private static Sender instance = null;
        private IServiceJavaReceiver proxy;

        private Sender()
        {
            proxy = new ServiceJavaReceiverClient();
        }

        public void createConnexion()
        {
            proxy = new ServiceJavaReceiverClient();
        }

        public void sendToCsMiddleware(string documentGUID, string decryptionCode, string secretInformation = null)
        {
            MSG message = new MSG();
            message.DocumentGUID = documentGUID;
            message.DecryptionCode = decryptionCode;
            message.SecretInformation = secretInformation;

            proxy.correctCodeFound(message);
        }

        public static Sender Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Sender();
                }
                return instance;
            }
        }


    }
}
