using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
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
        private const string AUTHENTICATION = "Authentication";
        private const string DECRYPTION = "Decryption";

        private TokenUser tokenUser;

        DecryptorManagerContainer decryptorManagerContainer;

        public Service1()
        {
            decryptorManagerContainer = DecryptorManagerContainer.Instance;
            Console.WriteLine("Une nouvelle instance de service est créee");
        }

        public STG m_service(STG msg)
        {
            STG messageResponse;

            switch (msg.OperationName)
            {
                case (DECRYPTION):

                    if(tokenUser.Token == msg.TokenUser)
                    {
                        tokenUser.TokenUserRefreshed();

                        Thread T1 = new Thread(() =>
                        {
                            DecryptorManager myDecryptorManager = new DecryptorManager((string)msg.Data[0]);
                            decryptorManagerContainer.SetDecryptorManagerInDictionary(myDecryptorManager.TextGUID, myDecryptorManager);

                            myDecryptorManager.DecryptWithEachKey();
                        });

                        T1.Start();

                        messageResponse = createMessageSTG(DECRYPTION, null, "File loaded and decryption started", msg.TokenApp, msg.TokenUser, null, null, true);
                    }
                    else
                    {
                        messageResponse = createMessageSTG(DECRYPTION, null, "The TokenUser has expired", msg.TokenApp, msg.TokenUser, null, null, false);
                    }
                    break;

                case (AUTHENTICATION):

                    tokenUser = new TokenUser();
                    
                    object[] authenticationData = new object[] { tokenUser.Token };

                    messageResponse = createMessageSTG(msg.OperationName, authenticationData, "Cette operation n'existe pas", msg.TokenApp, msg.TokenUser, msg.AppVersion, null, false);
                    break;


                default:
                    messageResponse = createMessageSTG(msg.OperationName, null, "Cette operation n'existe pas", msg.TokenApp, msg.TokenUser, msg.AppVersion, null, false);
                    break;
            }

            return messageResponse;
        }

        private STG createMessageSTG(string OperationName, object[] data, string info, string tokenApp, string tokenUser, string appVersion, string operationVersion, bool statutOp)
        {
            STG message = new STG();
            message.OperationName = OperationName;
            message.Data = data;
            message.StatutOP = statutOp;
            message.Info = info;
            message.TokenApp = tokenApp;
            message.TokenUser = tokenUser;
            message.AppVersion = appVersion;
            message.OperationVersion = operationVersion;

            return message;
        }

        public void Dispose()
        {
            Console.WriteLine("L'instance de client est fermée");
        }
    }
}
