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
            Console.WriteLine(alphabet.Count);

            foreach (string character in alphabet)
            {
                Console.WriteLine(character);
            }

            //test getPossibleKeys and display the number of combination possible
            Console.WriteLine(myDecryptorManager.getPossiblesKeys(alphabet).Count);

            Decryptor decryptor = new Decryptor();
            var result = decryptor.applyXOR("Clef", "Ceci est un texte");

            Console.WriteLine(result);

            Console.WriteLine("Appuyer sur entrer pour quitter...");
            Console.ReadLine();
        }
    }
}
