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
using System.Timers;
using Middleware.Model;
using Middleware.DAO;

namespace Middleware
{
    public class DecryptorManager: IDisposable
    {
        private string nameDocument;
        private string encryptedText;
        private string client;

        private List<string> possibleKeys;
        private string textGUID;

        private bool correctCodeFound = false;
        private System.Timers.Timer waitingForJEEResponse;

        public DecryptorManager(string nameDocument, string encrytedDocument, string client)
        {
            this.nameDocument = nameDocument;
            this.encryptedText = encrytedDocument;
            this.client = client;

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

            if (!correctCodeFound)
            {
                this.waitingForJEEResponse = CreateTimer();
                this.waitingForJEEResponse.Enabled = true;
            }
        }

        /*
         * Send to the Java EE Platform
         */
        private void Send(string code, string resultDecryption)
        {
            Sender.Instance.SendDecryptedAttempt(nameDocument, textGUID, code, resultDecryption, client + "@viacesi.fr");
        }


        public void CorrectKeyFound(string code, string secretInformation)
        {
            /*
             * Stop the Parallel.ForEach() Process
             */
            correctCodeFound = true;


            /*
             * Creates the Decrypted file and send it to the DB by using DAO
             */
            DecryptedFile decryptedFile = new DecryptedFile();
            decryptedFile.Name = nameDocument;
            decryptedFile.Client = client;
            decryptedFile.Code = code;
            decryptedFile.SecretInformation = secretInformation;
            decryptedFile.Plaintext = new Decryptor().applyXOR(code, encryptedText);

            InsertResultInDB(decryptedFile);
        }

        private void NoCorrectKeyFound()
        {
            NonDecryptedFile nonDecryptedFile = new NonDecryptedFile();
            nonDecryptedFile.Name = nameDocument;
            nonDecryptedFile.Client = client;
            nonDecryptedFile.EncryptedText = encryptedText;

            InsertResultInDB(nonDecryptedFile);
        }

        private void InsertResultInDB(IFile file)
        {
            if(file is DecryptedFile)
            {
                new DecryptedFileDAO().InsertDecryptedFile((DecryptedFile)file);
            }
            else
            {
                new NonDecryptedFileDAO().InsertDecryptedFile((NonDecryptedFile)file);
            }

            Dispose();
        }

        private System.Timers.Timer CreateTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                Console.WriteLine("Le délais de réponse est écoulé, la plateforme Java ne renverra aucun code");
                waitingForJEEResponse.Stop();
                waitingForJEEResponse.Dispose();
                NoCorrectKeyFound();
            };
            return timer;
        }

        public void Dispose()
        {
            Console.WriteLine("L'instance {0} DecryptorManager a finit son travail et se ferme", textGUID);
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
