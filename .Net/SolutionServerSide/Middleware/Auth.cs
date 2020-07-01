using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (user != null)
            {
                if (user.Password == password)
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
    }
}
