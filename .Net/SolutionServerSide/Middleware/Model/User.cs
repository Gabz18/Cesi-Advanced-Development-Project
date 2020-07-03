using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    class User
    {
        private int userID;
        private string username;
        private string password;
        private string salt;

        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Salt { get => salt; set => salt = value; }
    }
}
