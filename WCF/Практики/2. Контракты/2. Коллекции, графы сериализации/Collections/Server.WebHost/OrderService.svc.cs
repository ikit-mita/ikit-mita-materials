using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Server.DataAccess;
using Server.Logic;
using Shared.Model;

namespace Server.WebHost
{
    public class OrderService : IOrderService
    {
        private OrderRepository _repository = new OrderRepository();

        public IEnumerable<Order> GetOrders(OrderRequest request)
        {
            //Database.SetInitializer(new EntitiesContextInitializer());

            var res = _repository.GetOrders(request).ToList();
            return res;
        }
    }
}
