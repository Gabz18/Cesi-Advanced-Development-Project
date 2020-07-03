using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Middleware.DAO;
using Middleware.Model;

namespace Middleware
{
    public class Auth
    {
        IUserDAO userDAO;
        public Auth()
        {
            userDAO = new UserDAO();
        }

        public bool Authentication(string username, string password, string tokenApp)
        {

            User user = userDAO.FindByUserName(username);

            string saltedPassword = password + user.SaltPassword;
            string hashedPassword = MD5(saltedPassword);

            if (user != null)
            {
                if (user.Password == hashedPassword)
                {
                    return true;
                }
            }
            return false;
        }

        public TokenUser CreateTokenUser()
        {
            return new TokenUser();
        }

        public string toHash(HashAlgorithm algo, string password)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(
                string.Empty,
                result.Select(x => x.ToString("x2")));
        }


        public string MD5(string text)
        {
            var result = default(string);

            using (var algo = new MD5CryptoServiceProvider())
            {
                result = toHash(algo, text);
            }

            return result;
        }
    }
}
