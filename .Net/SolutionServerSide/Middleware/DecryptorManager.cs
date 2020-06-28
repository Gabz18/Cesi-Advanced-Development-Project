using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Middleware
{
    public class DecryptorManager
    {
        /// <summary>
        /// This function is based on the ASCII table for characters. The number 65 corresponds to A in the ASCII table and 90 to Z.
        /// So for each number between 65 and 90 include, it will get the Hexadecimal code (char) and finally convert it into 
        /// the corresponding character into string and add it to the list. 
        /// </summary>
        /// <returns>Return the complete list of the Alphabet in Uppercase</returns>
        public List<string> getAlphabetCharacter()
        {
            List<string> characters = new List<string>();

            for (int i = 65; i <= 90; i += 1)
            {
                characters.Add(((char)i).ToString());
            }

            return characters;
        }

        public List<string> getPossiblesKeys(List<string> characters)
        {
            List<string> combinations = new List<string>();

            for (int i = 0; i < characters.Count; i += 1)
            {
                for (int j = 0; j < characters.Count; j += 1)
                {
                    for (int k = 0; k < characters.Count; k += 1)
                    {
                        for (int l = 0; l < characters.Count; l += 1)
                        {
                            combinations.Add(characters[i] + characters[j] + characters[k] + characters[l]);
                        }
                    }
                }
            }
            return combinations;
        }

        public void tryEachCode(string documentToDecrypt, List<string> possibleKeys)
        {
            foreach (string key in possibleKeys)
            {
                string result = new Decryptor().applyXOR(key, documentToDecrypt);
                Console.WriteLine("Déchiffrement avec cette clé: {0}, voici le résultat: {1}", key, result);
            }
        }

        public void tryEachCodeTPL(string documentToDecrypt, List<string> possiblekeys)
        {
            var rnd = new Random();

            Parallel.ForEach(possiblekeys, (i, state) =>
            {

                //if (i == "JVCF")
                //{
                //    state.Stop();
                //    return;
                //}

                if (state.IsStopped)
                {
                    return;
                }
                else
                {
                    string result = new Decryptor().applyXOR(i, documentToDecrypt);
                    Console.WriteLine("Déchiffrement avec cette clé: {0} et ce Thread: {2}, voici le résultat: {1}", i, result, Thread.CurrentThread.ManagedThreadId.ToString());
                }
                
            });
        }
    }
}
