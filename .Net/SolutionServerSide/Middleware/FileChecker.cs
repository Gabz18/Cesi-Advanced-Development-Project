using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Middleware
{
    public class FileChecker
    {
        private static FileChecker instance;
        private Mutex mutexAccess;
        
        private Regex whiteCharacter;
        private Regex onlyAlphabeticAndWhiteCharact;
        private Regex onlyNumericAndWhiteCharact;
        private Regex onlyAlphanumericCharacterWhitWhiteCharact;

        private FileChecker()
        {
            whiteCharacter = new Regex(@"\s");
            onlyAlphabeticAndWhiteCharact = new Regex(@"^[A-Za-z + \s]+$");
            onlyNumericAndWhiteCharact = new Regex(@"^[0-9+\s]+$");
            onlyAlphanumericCharacterWhitWhiteCharact = new Regex(@"^[\w+\s]+$");

            mutexAccess = new Mutex();
        }

        public bool VerifyDoc(string documentName, string document)
        {
            mutexAccess.WaitOne();
            bool response;

            /*
             * If the string contains only alphabetic characters, it is rejected
             */
            if (onlyAlphabeticAndWhiteCharact.IsMatch(document))
            {
                Console.Write("Le document {0} n'est pas accepté, il ne possède que des caractères alphabetiques\n", documentName);
                response = false;
            }

            /*
             * If the string contains only numeric characters, it is rejected
             */
            else if (onlyNumericAndWhiteCharact.IsMatch(document))
            {
                Console.Write("Le document {0} n'est pas accepté, il ne possède que des caractères numériques\n", documentName);
                response = false;
            }

            /*
             * If the string contains only Alpha-numeric characters, it is rejected
             */
            else if (onlyAlphanumericCharacterWhitWhiteCharact.IsMatch(document))
            {
                Console.Write("Le document {0} n'est pas accepté, il ne possède que des caractères alpha-numériques\n", documentName);
                response = false;
            }

            /*
             * If the string contains more than 50% of White Characters, it is rejected
             */
            else if ((double)(((from Match m in whiteCharacter.Matches(document) select m.Value).ToList().Count * 100) / document.Length) >= 50)
            {
                Console.Write("Le document {0} n'est pas accepté, il possède plus de 50% de white characters\n", documentName);
                response = false;
            }

            /*
             * The string looks usable
             */
            else
            {
                response = true;
            }

            mutexAccess.ReleaseMutex();

            return response;
        }

        public static FileChecker Instance
        {
            get
            {
                if(instance == null)
                {
                    return instance = new FileChecker();
                }
                return instance;
            }
        }
    }
}
