using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class Writer : FullNamedDomainObject
    {
        public virtual ICollection<Book> Books { get; set; } 
    }
}
