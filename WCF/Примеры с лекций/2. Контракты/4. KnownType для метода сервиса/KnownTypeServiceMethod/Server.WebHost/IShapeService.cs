using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.WebHost.Model;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShapeService" in both code and config file together.
    [ServiceContract]

    public interface IShapeService
    {
        [OperationContract]
        [ServiceKnownType(typeof(Circle))]
        [ServiceKnownType(typeof(Square))]
        Shape CreateShape(int type);
    }
}
