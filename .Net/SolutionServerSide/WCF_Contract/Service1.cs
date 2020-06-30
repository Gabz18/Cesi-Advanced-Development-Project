using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Middleware;
//using WCF_Contract;

namespace WCF_Contract
{
    
    [ServiceBehavior(InstanceContextMode= InstanceContextMode.PerSession,
                 ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IService1, IDisposable
    {
        public int instanceCount;
        DecryptorManagerContainer decryptorManagerContainer;

        public Service1()
        {
            instanceCount++;
            decryptorManagerContainer = DecryptorManagerContainer.Instance;
            Console.WriteLine("Une Instance de service est créee");
        }

        public STG m_service(STG msg)
        {
            STG messageResponse;

            switch (msg.OperationName)
            {
                case ("Decryption"):

                    DecryptorManager myDecryptorManager = new DecryptorManager((string)msg.Data[0]);
                    decryptorManagerContainer.setElementDictionnary(myDecryptorManager.DecryptionManagerGUID, myDecryptorManager);

                    object [] response = myDecryptorManager.tryEachCodeTPL();
                    return createMessageSTG("Response", response);
                    

                 //case ("StopDecryption"):
                 //   DecryptorManager decryptorManager = decryptorManagerContainer.getElementDictionary((string)msg.Data[0]);
                 //   decryptorManager.responseReceived((string)msg.Data[1]);
                    
                 //   break;
            }
            return msg;
        }

        private STG createMessageSTG(string OperationName, object[] data)
        {
            STG message = new STG();
            message.OperationName = OperationName;
            message.Data = data;

            return message;
        }

        public void Dispose()
        {
            Console.WriteLine("L'instance de client est fermée");
        }
    }
}
