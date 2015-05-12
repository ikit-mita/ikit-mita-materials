using System;
using System.Data.Entity;
using Shared.Model;

namespace Server.DataAccess
{
    public class EntitiesContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var bookProduct = new Product {Name = "Book"};
            var foodProduct = new Product {Name = "Food"};
            
            context.Products.Add(bookProduct);
            context.Products.Add(foodProduct);

            var customer1 = new Customer {Name = "Ivanov"};
            var customer2 = new Customer { Name = "Petrov" };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);

            context.SaveChanges();

            var order1 = new Order();
            order1.Customer = customer1;
            order1.Date = DateTime.Now;

            context.SaveChanges();
            
            var orderItem1 = new OrderItem
            {
                Product = bookProduct,
                Order = order1,
                Price = 100,
                Amount = 1
            };

            var orderItem2 = new OrderItem
            {
                Product = foodProduct,
                Order = order1,
                Price = 200,
                Amount = 2
            };

            context.OrderItems.Add(orderItem1);
            context.OrderItems.Add(orderItem2);

            context.SaveChanges();

        }
    }
}
