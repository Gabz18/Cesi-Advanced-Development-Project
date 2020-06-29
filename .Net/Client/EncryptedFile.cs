using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class EncryptedFile
    {
        public string name;
        public string content;


        public EncryptedFile(string name, string content)
        {
            this.name = name;
            this.content = content;
        }

    }
}
