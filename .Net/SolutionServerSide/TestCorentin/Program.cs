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

            DecryptorManager myDecryptorManager = new DecryptorManager();

            //test getAlphabetCharacter and display result
            List<string> alphabet = myDecryptorManager.getAlphabetCharacter();
            List<string> keys = myDecryptorManager.getPossiblesKeys(alphabet);

            myDecryptorManager.tryEachCodeTPL("0?z*/3)y/4z-?\".<z.(±)z)07*6<", keys);

            Console.WriteLine("Appuyer sur entrer pour quitter...");
            Console.ReadLine();
        }
    }
}
