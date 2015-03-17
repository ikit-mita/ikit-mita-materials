using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsManager.Model
{
    public class Tenant : IDomainObject
    {
        public int Id { get; set; }

        public string Name { get;set; }

        public DateTime Birthday { get; set; }

        public double Debt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
