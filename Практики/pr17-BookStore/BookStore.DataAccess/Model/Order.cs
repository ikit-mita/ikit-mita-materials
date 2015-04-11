using System;
using System.Collections.Generic;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class Order : DomainObject
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderedBook> OrderedBooks { get; set; } 
    }
}
