using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Shared.Model;

namespace Server.WebHost
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat] 
        IEnumerable<Order> GetOrders(OrderRequest request);
    }
}
