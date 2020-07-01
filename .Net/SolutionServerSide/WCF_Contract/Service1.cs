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
        /*
         * Possible Actions
         */
        private const string AUTHENTICATION = "Authentication";
        private const string DECRYPTION = "Decryption";
        private const string GET_FILES = "GetFiles";

        /*
         * Information on the session
         */
        private TokenUser sessionTokenUser;
        private string sessionTokenApp;
        private string client;

        DecryptorManagerContainer decryptorManagerContainer;

        public Service1()
        {
            //
            decryptorManagerContainer = DecryptorManagerContainer.Instance;
            Console.WriteLine("Une nouvelle instance de service est créee");
        }

        public STG m_service(STG msg)
        {
            bool statutOP = msg.StatutOP;
            string info = msg.Info;
            object[] data = msg.Data;
            string operationName = msg.OperationName;
            string tokenApp = msg.TokenApp;
            string tokenUser = msg.TokenUser;
            string appVersion = msg.AppVersion;
            string operationVersion = msg.OperationVersion;


            switch (msg.OperationName)
            {
                case (DECRYPTION):

                    /*
                     * Verify that the Session is still available
                     */
                    if(sessionTokenUser.Token == tokenUser)
                    {
                        sessionTokenUser.TokenUserRefreshed();

                        Thread DecryptionProcess = new Thread(() =>
                        {
                            DecryptorManager myDecryptorManager = new DecryptorManager((string)data[0], (string)data[1], client);
                            decryptorManagerContainer.SetDecryptorManagerInDictionary(myDecryptorManager.TextGUID, myDecryptorManager);

                            //myDecryptorManager.DecryptWithEachKey();
                            myDecryptorManager.DecryptSingle("CU", (string)data[1]);

                        });

                        DecryptionProcess.Start();

                        return createMessageSTG(DECRYPTION, null, "File loaded and decryption started", sessionTokenApp, sessionTokenUser.Token, appVersion, operationVersion, true);
                    }

                    /*
                     * TokenUser has expired the functionality is not available
                     */
                    else
                    {
                       return createMessageSTG(DECRYPTION, data, "The TokenUser has expired", tokenApp, tokenUser, appVersion, operationVersion, false);
                    }
                
                
                case (AUTHENTICATION):

                    Auth authenticator = new Auth();

                    if (authenticator.Authentication((string)data[0], (string)data[1], tokenApp) == true)
                    {
                        sessionTokenUser = authenticator.CreateTokenUser();
                        sessionTokenApp = tokenApp;
                        client = (string)data[0];

                        Console.Write("Authentification réussie, le client {0} peut maintenant accèder à la session avec sa paire TokenUser/TokenApp: {1}/{2}", client, sessionTokenUser, sessionTokenApp);

                        return createMessageSTG(AUTHENTICATION, null, "Authentication success, TokenUser created", sessionTokenApp, sessionTokenUser.Token, appVersion, operationVersion, true);
                    }

                    /*
                     * Authentication failed
                     */
                    else
                    {
                        Dispose();
                        return createMessageSTG(AUTHENTICATION, data, "User or Password Invalid", tokenApp, tokenUser, appVersion, operationVersion, false);
                    }


                //case (GET_FILES):
                   


                //        return createMessageSTG();


                default:
                    return createMessageSTG(operationName, data, "This operation doesn't exist",tokenApp, tokenUser, appVersion, operationVersion, false);
            }
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
            if(sessionTokenUser != null)
            {
                sessionTokenUser.DeleteTokenUser();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L'instance de client est fermée");
        }
    }
}
