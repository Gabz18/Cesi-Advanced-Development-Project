using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Model
{
    class User
    {
        private int userID;
        private string username;
        private string password;
        private string saltPassword;

        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string SaltPassword { get => saltPassword; set => saltPassword = value; }
    }
}
