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
            //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
            proxy = new Service2Client();
            sendMessageAccess = new Mutex();
        }

        public void sendMessageToJava(string documentGUID, string code, string resultDecryption)
        {
            sendMessageAccess.WaitOne();

            //JavaMessage message = this.createMessageJava(documentGUID, code, resultDecryption);

            
            proxy.verifyData(documentGUID, code, resultDecryption);

            sendMessageAccess.ReleaseMutex();
        }

        //private JavaMessage createMessageJava(string documentGUID, string code, string resultDecryption)
        //{
        //    JavaMessage javaMessage = new JavaMessage();
        //    javaMessage.DocumentGUID = documentGUID;
        //    javaMessage.Code = code;
        //    javaMessage.ResultDecryption = resultDecryption;

        //    return javaMessage;
        //}

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
