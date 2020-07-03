using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Model;

namespace Middleware.DAO
{
    interface INonDecryptedFileDAO
    {
        bool InsertNonDecryptedFile(NonDecryptedFileDAO file);
        List<NonDecryptedFileDAO> FindByClient(string client);
    }
}
