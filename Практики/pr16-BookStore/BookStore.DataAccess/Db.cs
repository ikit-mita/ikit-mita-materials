using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookStore.DataAccess.Model;

namespace BookStore.DataAccess
{
    public class Db : DbContext
    {
        public Db() : base("BookStoreDb") { }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Branch> Branches { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<BookCategory> BookCategories { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Writer> Writers { get; set; }
        public IDbSet<BookAmount> BookAmounts { get; set; }
        public IDbSet<OrderedBook> OrderedBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Employee)
                .WithOptional(e => e.User);
        }
    }
}
