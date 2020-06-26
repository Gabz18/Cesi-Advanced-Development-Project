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
    }
}
