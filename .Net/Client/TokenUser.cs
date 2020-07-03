using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class TokenUser
    {
        private string token;

        public TokenUser(string token)
        {
            this.token = token;
        }

        public string Token { get => token; }
    }
}
