using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    interface IDecryptedFileDAO
    {
        bool InsertDecryptedFile(DecryptedFile file);
        List<DecryptedFile> FindByClient(string client);
    }
}
