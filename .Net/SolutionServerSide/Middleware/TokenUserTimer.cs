using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Middleware
{
    public class TokenUser
    {
        private Timer tokenUserTimer;
        private string token;

        public TokenUser()
        {
            token = CreateToken();
            SetTimer();
        }

        private void SetTimer()
        {
            tokenUserTimer = new Timer(30000);
            tokenUserTimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                Console.WriteLine("Le TokenUser {0} n'est plus valable", token);
                token = null;
                tokenUserTimer.Stop();
                tokenUserTimer.Dispose();
            };
            tokenUserTimer.Enabled = true;
        }

        private string CreateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public void DeleteTokenUser()
        {
            token = null;
            tokenUserTimer.Stop();
            tokenUserTimer.Dispose();
        }

        public void TokenUserRefreshed()
        {
            tokenUserTimer.Stop();
            tokenUserTimer.Start();
        }

        public string Token { get => token; }
    }
}
