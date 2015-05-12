using System.Data.Entity.ModelConfiguration.Conventions;
using Shared.Model;

namespace Server.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataModel")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }


    
}