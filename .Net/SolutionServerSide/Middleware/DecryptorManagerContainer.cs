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
        private Dictionary<string, DecryptorManager> decryptorManagerDictionary;

        private DecryptorManagerContainer()
        {
            decryptorManagerDictionary = new Dictionary<string, DecryptorManager>();
            Console.WriteLine("Instance créee");
        }

        public DecryptorManager GetDecryptorManager(string textGUID)
        {
            try
            {
                return decryptorManagerDictionary[textGUID];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Decryptor for uuid: {0} not found", textGUID);
                return null;
            }
        }

        public void SetDecryptorManagerInDictionary(string textGUID, DecryptorManager decryptorManager)
        {
            try
            {
                decryptorManagerDictionary.Add(textGUID, decryptorManager);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Impossible to add an object for this uuid: {0}, because it already exists", textGUID);
            }
        }

        public void RemoveDecryptorManagerFromDictionary(string textGUID)
        {
            if (!decryptorManagerDictionary.ContainsKey(textGUID))
            {
                Console.WriteLine("The uuid {0} was not found in the Dictionary", textGUID);
            }
            else
            {
                decryptorManagerDictionary.Remove(textGUID);
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
