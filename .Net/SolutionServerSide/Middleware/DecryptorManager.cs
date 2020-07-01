using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Net.Http.Headers;
using Middleware.ServiceReference1;
using System.Linq.Expressions;

namespace Middleware
{
    public class DecryptorManager: IDisposable
    {
        private string nameDocument;
        private string encryptedText;
        private string client;

        private IDecryptedFileDAO decryptedFileDAO;
        private DecryptedFile decryptedFile;
        private Sender sender;

        private List<string> possibleKeys;
        private string textGUID;

        private bool correctCodeFound = false;

        public DecryptorManager(string nameDocument, string encrytedDocument, string client)
        {
            this.nameDocument = nameDocument;
            this.encryptedText = encrytedDocument;
            this.client = client;

            decryptedFileDAO = new DecryptedFileDAO();
            sender = Sender.Instance;

            decryptedFile = new DecryptedFile();
            decryptedFile.Client = client;
            decryptedFile.Name = nameDocument;

            textGUID = Guid.NewGuid().ToString();
            possibleKeys = this.GetPossibleKeys2(this.GetAlphabetCharacter());
        }

        /// <summary>
        /// This function is based on the ASCII table for characters. The number 65 corresponds to A in the ASCII table and 90 to Z.
        /// So for each number between 65 and 90 include, it will get the Hexadecimal code (char) and finally convert it into 
        /// the corresponding character into string and add it to the list. 
        /// </summary>
        /// <returns>Return the complete list of the Alphabet in Uppercase</returns>
        public List<string> GetAlphabetCharacter()
        {
            List<string> characters = new List<string>();

            for (int i = 65; i <= 90; i += 1)
            {
                characters.Add(((char)i).ToString());
            }

            return characters;
        }

        public List<string> GetPossibleKeys(List<string> characters)
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

        public List<string> GetPossibleKeys2(List<string> characters)
        {
            List<string> combinations = new List<string>();

            for (int i = 0; i < characters.Count; i += 1)
            {
                for (int j = 0; j < characters.Count; j += 1)
                {
               
                     combinations.Add(characters[i] + characters[j]);
                }
            }
            return combinations;
        }

        public void DecryptSingle(string key, string encryptedText)
        {
            string decryptedTextResult = new Decryptor().applyXOR(key, encryptedText);
            Console.WriteLine("Déchiffrement avec cette clé: {0} et ce Thread: {2}, voici le résultat: {1}", key, decryptedTextResult, Thread.CurrentThread.ManagedThreadId.ToString());
            Send(key, decryptedTextResult);
        }

        public void DecryptWithEachKey()
        {
            Console.WriteLine("Je suis entrain de traiter la demande pour ce texte chiffré {0} ayant pour Guid: {1}", encryptedText, textGUID);
            
            Parallel.ForEach(possibleKeys, (key) =>
            {

                if (correctCodeFound)
                {
                    return;
                }
                else
                {
                    string decryptedTextResult = new Decryptor().applyXOR(key, encryptedText);

                    Console.WriteLine("Déchiffrement avec cette clé: {0} et ce Thread: {2}, voici le résultat: {1}", key, decryptedTextResult, Thread.CurrentThread.ManagedThreadId.ToString());
                    Send(key, decryptedTextResult);
                }
                
            });

            // Attend deux minutes après la sortie du Parallel.ForEach
        }


        private void Send(string code, string resultDecryption)
        {
            sender.SendDecryptedAttempt(nameDocument, textGUID, code, resultDecryption, client + "@viacesi.fr");
        }


        public void CorrectKeyFound(string code, string secretInformation)
        {
            /*
             * Stop the Parallel.ForEach() Process
             */
            correctCodeFound = true;

            decryptedFile.Code = code;
            decryptedFile.SecretInformation = secretInformation;
            decryptedFile.Plaintext = new Decryptor().applyXOR(code, encryptedText);

            InsertResultInDB();
        }

        private void InsertResultInDB()
        {
            decryptedFileDAO.InsertDecryptedFile(decryptedFile);
        }

        public void Dispose()
        {
            DecryptorManagerContainer.Instance.RemoveDecryptorManagerFromDictionary(textGUID);
        }
          
        public string TextGUID
        {
            get
            {
                return textGUID;
            }
        }
    }
}
