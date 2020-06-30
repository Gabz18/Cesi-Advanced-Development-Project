using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Middleware;

namespace TestCorentin
{
    class Program
    {
        static void Main(string[] args)
        {
            Sender mySender = Sender.Instance;
            mySender.sendMessageToJava();

            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit....");
        }
    }
}
