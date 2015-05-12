using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Logic.OrderServiceReference;
using Shared.Model;

namespace Client.Logic
{
    public class OrderRepositoryProxy
    {
        private readonly OrderServiceClient _serviceClient = new OrderServiceClient();
        
        //TODO важно! метод должен возвращать Task<List<Order>>, а не List<Order>
        public Task<List<Order>> GetOrdersAsync(OrderRequest request)
        {
            return _serviceClient.GetOrdersAsync(request);
        }
    }
}
