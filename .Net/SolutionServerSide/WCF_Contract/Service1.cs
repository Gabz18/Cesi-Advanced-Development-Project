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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        public int instanceCount;

        public string m_service(STG msg)
        {
            return "salut bg";
        }


        public void simpleFunction(string clientName)
        {
            instanceCount++;
            DecryptorManager myDecryptorManager = new DecryptorManager();
            List<string> alphabet = myDecryptorManager.getAlphabetCharacter();

            Console.WriteLine("instance numéro: {0}, thread numéro: {1}, client name: {2}", instanceCount.ToString(), Thread.CurrentThread.ManagedThreadId.ToString(), clientName);

            //foreach(string character in alphabet)
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("instance numéro: {0}, thread numéro: {1}, client name: {2}", instanceCount.ToString(), Thread.CurrentThread.ManagedThreadId.ToString(), clientName);
            //    Console.WriteLine(character);

        }
    }
}
