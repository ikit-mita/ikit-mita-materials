using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Logic;
using Shared.Utils;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFaultService" in both code and config file together.
    [ServiceContract]
    public interface IFaultService
    {
        [OperationContract]
        [FaultContract(typeof(GetDataFault))]
        string GetData();
    }
}
