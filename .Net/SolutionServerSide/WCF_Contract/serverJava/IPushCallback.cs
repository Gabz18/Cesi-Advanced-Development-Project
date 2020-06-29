using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Contract
{
    interface IPushCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceivedData(string data);
    }
}
