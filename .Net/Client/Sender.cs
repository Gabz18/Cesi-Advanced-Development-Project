using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Navigation;
using Client.ServiceReference1;

namespace Client
{
    class Sender : IDisposable
    {
        private static Sender instance;
        private Service1Client proxy;
        private string tokenUser = null;

        private const string AUTHENTICATION = "Authentication";
        private const string DECRYPTION = "Decryption";
        private Sender()
        {
        }

        private void Login(string username, string password)
        {
            proxy = new Service1Client();
            /*proxy.ClientCredentials.UserName.UserName = "Ben";
            proxy.ClientCredentials.UserName.Password = "Ben";
            proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;*/
            proxy.Open();
        }

        public bool Authentication(string username, string password)
        {

            Login(username, password);
            STG response = proxy.m_service(this.createMessage(AUTHENTICATION, new object[] { username, password }));

            if(response.StatutOP == true && response.TokenUser != null)
            {
                tokenUser = response.TokenUser;
                return true;
            }
            else
            {
                if(response.Info == "User or Password Invalid")
                {
                    proxy.Close();
                }
                return false;
            }
        }

        public bool sendEncryptedDocument(object[] data)
        {
            STG response = proxy.m_service(this.createMessage(DECRYPTION, data));
            
            if(response.StatutOP == true)
            {
                return true;
            }
            else
            {
                if(response.Info == "The TokenUser has expired")
                {
                    proxy.Close();
                }
                return false;
            }
        }

        private STG createMessage(string operationName, object[] data)
        {
            STG myMessage = new STG();
            myMessage.OperationName = operationName;
            myMessage.Data = data;
            myMessage.TokenApp = AppToken.token;
            myMessage.TokenUser = tokenUser;

            return myMessage;
        }

        public void Dispose()
        {
            Console.WriteLine("La connexion avec le serveur est terminée");
            proxy.Close();
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
