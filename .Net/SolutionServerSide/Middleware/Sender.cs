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
        private IService2 proxy;
        private Mutex sendMessageAccess;
        
        private Sender()
        {
            proxy = new Service2Client();
            sendMessageAccess = new Mutex();
        }

        public void SendDecryptedAttempt(string documentGUID, string code, string resultDecryption)
        {
            sendMessageAccess.WaitOne();

            // Java SOAP

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
