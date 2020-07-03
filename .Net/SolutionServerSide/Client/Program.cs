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

            //+InnerException  { "Le certificat X.509 CN=WCFserverCert ne se trouve pas dans un magasin de personnes de confiance. Échec de la génération de la chaîne CN=WCFserverCert du certificat X.509. Le certificat qui a été utilisé comporte une chaîne d'approbation impossible à vérifier. Remplacez ce certificat ou modifiez l'élément certificateValidationMode. Une chaîne de certificats a été traitée mais s’est terminée par un certificat racine qui n’est pas approuvé par le fournisseur d’approbation.\r\n"}
            //System.Exception { System.IdentityModel.Tokens.SecurityTokenValidationException}


        }
    }
}
