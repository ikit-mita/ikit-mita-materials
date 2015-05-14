using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Logic;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FaultService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FaultService.svc or FaultService.svc.cs at the Solution Explorer and start debugging.
    [ErrorHandlerBehavior]
    public class FaultService : IFaultService
    {
        private readonly Repository _repository = new Repository();

        public string GetData()
        {
            return _repository.GetData();
        }
    }
}
