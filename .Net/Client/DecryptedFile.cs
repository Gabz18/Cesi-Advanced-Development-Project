using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class DecryptedFile
    {
        private string name;
        private string content;
        private string decryptionKey;
        private string secretInformation;


        public DecryptedFile(string name, string content, string decryptionKey, string secretInformation)
        {
            this.name = name;
            this.content = content;
            this.decryptionKey = decryptionKey;
            this.secretInformation = secretInformation;
        }

        public string Name { get =>  name; set => name = value; }
        public string Content { get => content; set => content = value; }
        public string DecryptionKey { get => decryptionKey; set => decryptionKey = value; }
        public string SecretInformation { get => secretInformation; set => secretInformation = value; }
    }
}
