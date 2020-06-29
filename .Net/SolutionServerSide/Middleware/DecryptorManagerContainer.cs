using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public class DecryptorManagerContainer
    {
        private static DecryptorManagerContainer instance = null;
        private Dictionary<string, DecryptorManager> myDictionary;

        private DecryptorManagerContainer()
        {
            myDictionary = new Dictionary<string, DecryptorManager>();
            Console.WriteLine("Instance créee");
        }

        public DecryptorManager getElementDictionary(string uuid)
        {
            try
            {
                return myDictionary[uuid];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Decryptor for uuid: {0} not found", uuid);
                return null;
            }
        }

        public void setElementDictionnary(string uuid, DecryptorManager decryptorManager)
        {
            try
            {
                myDictionary.Add(uuid, decryptorManager);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Impossible to add an object for this uuid: {0}, because it already exists", uuid);
            }
        }

        public void removeElementDictionary(string uuid)
        {
            if (!myDictionary.ContainsKey(uuid))
            {
                Console.WriteLine("The uuid {0} was not found in the Dictionary", uuid);
            }
            else
            {
                myDictionary.Remove(uuid);
            }
        }

        public static DecryptorManagerContainer Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DecryptorManagerContainer();
                }
                return instance;
            }
        }
    }
}
