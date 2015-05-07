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
    [ServiceKnownType(typeof(Circle))]
    [ServiceKnownType(typeof(Square))]

    public interface IShapeService
    {
        [OperationContract]
        Shape CreateShape(int type);
    }
}
