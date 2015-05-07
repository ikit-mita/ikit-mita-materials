using Server.WebHost.Model;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompositeContractService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompositeContractService.svc or CompositeContractService.svc.cs at the Solution Explorer and start debugging.
    public class CompositeTypeService : ICompositeTypeService
    {
        public CompositeType CompositeType(CompositeType type)
        {
            return new CompositeType
            {
                StringValue = "ServerValue",
                BoolValue = true,
            };
        }

        public Answer EnumType(bool answer)
        {
            return answer ? Answer.Yes : Answer.No;
        }
    }
}
