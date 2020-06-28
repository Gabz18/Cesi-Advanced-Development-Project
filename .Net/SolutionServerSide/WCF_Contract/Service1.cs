using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public int instanceCount;
        string clientInstanceName;

        Service1()
        {
            instanceCount++;
            Console.WriteLine("Une Instance de service est créee");
        }

        public string m_service(STG msg)
        {
            return "salut bg";
        }

        public void setClientName(string clientName)
        {
            this.clientInstanceName = clientName;
            Console.WriteLine("le client de cette instance est: {0}", clientName);
        }


        public void simpleFunction()
        {
            DecryptorManager myDecryptorManager = new DecryptorManager();
            List<string> alphabet = myDecryptorManager.getAlphabetCharacter();

            Console.WriteLine("instance numéro: {0}, thread numéro: {1}, client name: {2}", instanceCount.ToString(), Thread.CurrentThread.ManagedThreadId.ToString(), clientInstanceName);

            //foreach (string character in alphabet)
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("instance numéro: {0}, thread numéro: {1}, client name: {2}", instanceCount.ToString(), Thread.CurrentThread.ManagedThreadId.ToString(), clientInstanceName);
            //    Console.WriteLine(character);
            //}
        }


        public void Dispose()
        {
            Console.WriteLine("L'instance de client: {0} est fermée", clientInstanceName);
        }
    }
}
