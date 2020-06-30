using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using Client.ServiceReference1;

namespace Client
{
    class Sender
    {
        private static Sender instance;
        private IService1 proxy;
        private Sender()
        {
            proxy = new Service1Client();
        }

        public async Task<STG> sendEncryptedDocumentAsync(object[] data) 
        { 
            STG response = await proxy.m_serviceAsync(this.createMessage("Decryption", data));
            return response;
        }

        public STG sendEncryptedDocument(object[] data)
        {
            STG response = proxy.m_service(this.createMessage("Decryption", data));
            return response;
        }


        private STG createMessage(string operationName, object[] data)
        {
            STG myMessage = new STG();
            myMessage.OperationName = operationName;
            myMessage.Data = data;

            return myMessage;
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
