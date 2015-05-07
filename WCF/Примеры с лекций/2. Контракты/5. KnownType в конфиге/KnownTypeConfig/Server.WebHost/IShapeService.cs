using System.ServiceModel;
using Server.WebHost.Model;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShapeService" in both code and config file together.
    [ServiceContract]
    public interface IShapeService
    {
        [OperationContract]
        Shape CreateShape(int type);
    }
}
