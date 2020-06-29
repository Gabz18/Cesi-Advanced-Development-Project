using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Middleware.ServiceReference1;

namespace Middleware
{
    class Sender : ServiceReference1.IService2Callback
    {
        public ManualResetEvent ReceivedDataCompleted { get; set; }

        public Sender()
        {
            ReceivedDataCompleted = new ManualResetEvent(false);
        }
        public void ReceivedData(string data)
        {
            Console.WriteLine("Received Data");
            ReceivedDataCompleted.Set();
        }
    }
}
