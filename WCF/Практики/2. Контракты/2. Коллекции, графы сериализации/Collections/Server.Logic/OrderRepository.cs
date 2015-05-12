using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.DataAccess;
using Shared.Model;

namespace Server.Logic
{
    public class OrderRepository
    {
        private DataContext _dataContext = new DataContext();

        public IEnumerable<Order> GetOrders(OrderRequest request)
        {
            var result = _dataContext.Orders as IQueryable<Order>;

            if (request.IncludeOrderItems)
            {
                result = result.Include("OrderItems");
                result = result.Include("OrderItems.Product");
                result = result.Include("OrderItems.Order");
            }

            if (request.IncludeCustomer)
            {
                result = result.Include("Customer");
            }

            return result;
        }
    }
}
