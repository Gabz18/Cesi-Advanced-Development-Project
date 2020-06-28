using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientNoSecure.ServiceReference1;


namespace ClientNoSecure
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientName;
            
            Console.WriteLine("Enter a client name:");
            clientName = Console.ReadLine();
            
            IService1 proxy = new Service1Client();

            proxy.setClientName(clientName);

            for(int i = 0; i < 4; i += 1)
            {
                proxy.simpleFunction();
            }

        

            Console.WriteLine("Tap Enter to finish the process");
            Console.ReadLine();
        }
    }
}
