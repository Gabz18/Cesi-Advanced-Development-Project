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

        public void testConcurrencyWithTPL()
        {
            DecryptorManager myDecryptorManager = new DecryptorManager();

            //test getAlphabetCharacter and display result
            List<string> alphabet = myDecryptorManager.getAlphabetCharacter();
            List<string> keys = myDecryptorManager.getPossiblesKeys(alphabet);

            myDecryptorManager.tryEachCodeTPL("0?z*/3)y/4z-?\".<z.(±)z)07*6<", keys);
        }


        public void Dispose()
        {
            Console.WriteLine("L'instance de client: {0} est fermée", clientInstanceName);
        }
    }
}
