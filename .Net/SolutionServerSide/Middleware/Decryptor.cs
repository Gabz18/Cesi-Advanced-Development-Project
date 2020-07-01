using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public class Decryptor
    {
        public string applyXOR(string key, string encryptedText)
        {
            var result = new StringBuilder();

            for (int c = 0; c < encryptedText.Length; c++)
                result.Append((char)((uint)encryptedText[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
    }
}
