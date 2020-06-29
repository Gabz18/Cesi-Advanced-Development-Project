using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCF_Contract;
using Middleware;

namespace ServerNoSecure
{
    class Program
    {
        static void Main(string[] args)
        {
            ini_serv();
        }

        static void ini_serv()
        {
            DecryptorManagerContainer singletonDecryptorManager = DecryptorManagerContainer.Instance;

            ServiceHost host = new ServiceHost(typeof(Service1));

            host.Open();

            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit....");

            Console.ReadLine();

            host.Close();
        }
    }
}
