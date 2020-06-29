using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

        public void sendMessageToJava(string documentGUID, string code, string documentDecrypted)
        {
            sendMessageAccess.WaitOne();
            proxy.verifyData(this.createMessageJava(documentGUID, code, documentDecrypted));

            sendMessageAccess.ReleaseMutex();
        }

        private JavaMessage createMessageJava(string documentGUID, string code, string documentDecrypted)
        {
            JavaMessage javaMessage = new JavaMessage();
            javaMessage.DocumentGUID = documentDecrypted;
            javaMessage.Code = code;
            javaMessage.DocumentDecrypted = documentDecrypted;

            return javaMessage;
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
