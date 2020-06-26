using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceMiddlewareCsharp;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string username, password;
            Console.WriteLine("   Enter username:");
            username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            password = Console.ReadLine();

            var proxy = new Service1Client();

            proxy.ClientCredentials.UserName.UserName = username;
            proxy.ClientCredentials.UserName.Password = password;

            proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;

            Console.WriteLine(proxy.m_service(new STG()));


        }
    }
}
