using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestCorentin.WebReference;

namespace TestCorentin
{
    class Sender
    {
        private static Sender instance;
        private WebReference.FileService proxy;
        private Mutex sendMessageAccess;
        private Sender()
        {
            proxy = new FileService();
            sendMessageAccess = new Mutex();
        }

        public void sendMessageToJava()
        {
            string code = "TEST";
            string resultDecryption = "dgzytufguy";
            //sendMessageAccess.WaitOne();
            string decryptorManagerGUID = Guid.NewGuid().ToString();
            bool FileProcessingStarted = true;
            bool FileStartedSpecified = true;
            proxy.fileAnalysisProcessStart("testFileName", decryptorManagerGUID, code, resultDecryption, "ben@salut.fr", out FileProcessingStarted, out FileStartedSpecified);
            


            //sendMessageAccess.ReleaseMutex();
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
