using System.ServiceModel;
using Server.WebHost.Model;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompositeContractService" in both code and config file together.
    [ServiceContract]
    public interface ICompositeTypeService
    {
        [OperationContract]
        CompositeType CompositeType(CompositeType type);

        [OperationContract]
        Answer EnumType(bool ans);
    }
}
