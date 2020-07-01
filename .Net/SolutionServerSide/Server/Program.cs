using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCF_Contract;
using Server.ServiceReference1;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ini_serv();
        }

        static void ini_serv()
        {
            //DecryptorManagerContainer.Instance;

            ServiceHost hostNetTCP = new ServiceHost(typeof(Service1));
            ServiceHost hostWS = new ServiceHost(typeof(ServiceJavaReceiver));

            hostNetTCP.Open();
            hostWS.Open();

            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit....");

            Console.ReadLine();

            hostNetTCP.Close();
            hostWS.Close();
        }
    }
}
