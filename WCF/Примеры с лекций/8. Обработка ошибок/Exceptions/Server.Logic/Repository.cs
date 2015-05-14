using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logic
{
    public class Repository
    {
        public string GetData()
        {
            throw new FaultException<GetDataFault>(new GetDataFault());
            
            return "Data";
        }
    }
}
