using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IdentityModel.Selectors;
using System.Web;
using System.IdentityModel.Tokens;

namespace Middleware
{
    class ImplUserNameValidator : UserNamePasswordValidator
    {
        string username;
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "ben" && password == "ben"))
            {
                throw new SecurityTokenException("Unknow username or password");
            }

        }


    }
}
