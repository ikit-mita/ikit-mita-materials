using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class Branch : NamedDomainObject
    {
        public string Address { get; set; }
    }
}
