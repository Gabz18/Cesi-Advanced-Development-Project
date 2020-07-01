using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    interface IUserDAO
    {
        User FindByUserName(string username);
    }
}
