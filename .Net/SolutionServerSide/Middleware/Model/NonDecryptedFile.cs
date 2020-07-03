using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Model
{
    public class NonDecryptedFile: IFile
    {
        private int id;
        private string name;
        private string client;
        private string encryptedText;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Client { get => client; set => client = value; }
        public string EncryptedText { get => encryptedText; set => encryptedText = value; }
    }
}
