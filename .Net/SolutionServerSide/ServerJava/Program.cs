using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerJava
{
    class Program
    {
        static void Main(string[] args)
        {
            ini_serv();
        }

        static void ini_serv()
        {
            ServiceHost host = new ServiceHost(typeof(Service2));

            host.Open();

            Console.WriteLine("Service is running a");
            Console.WriteLine("Press enter to quit....");

            Console.ReadLine();

            host.Close();
        }
    }
}
