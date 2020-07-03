using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Middleware.ServiceReference1;

namespace Middleware
{
    class Sender
    {
        private static Sender instance;
        private ServiceReference1.FileEndpointClient proxy;
        private Mutex sendMessageAccess;
        
        private Sender()
        {
            proxy = new FileEndpointClient();
            sendMessageAccess = new Mutex();
        }

        public void SendDecryptedAttempt(string nameDocument, string textGUID, string code, string resultDecryption, string mailClient)
        {
            sendMessageAccess.WaitOne();

            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] resultDecryptionByte = utf8.GetBytes(resultDecryption);

            proxy.fileAnalysisProcessStart(nameDocument, textGUID, code, resultDecryptionByte, mailClient);
            Console.Write("j'envois");

            sendMessageAccess.ReleaseMutex();
        }

        public static Sender Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sender();
                }
                return instance;
            }
        }
    }
}
