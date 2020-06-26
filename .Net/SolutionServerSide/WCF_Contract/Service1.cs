using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//using WCF_Contract;

namespace WCF_Contract
{
   
    public class Service1 : IService1
    {
        public string m_service(STG msg)
        {
            return "salut bg";
        }
    }
}
