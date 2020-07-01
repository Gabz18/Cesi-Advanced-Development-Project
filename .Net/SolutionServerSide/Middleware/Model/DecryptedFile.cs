using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    class DecryptedFile
    {
        private int id;
        private string name;
        private string client;
        private string code;
        private string plaintext;
        private string secretInformation;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Client { get => client; set => client = value; }
        public string Code { get => code; set => code = value; }
        public string Plaintext { get => plaintext; set => plaintext = value; }
        public string SecretInformation { get => secretInformation; set => secretInformation = value; }
    }
}
