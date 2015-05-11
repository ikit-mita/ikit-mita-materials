using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsManager.Model
{
    public class TenantRepository : MemoryRepository<Tenant>
    {
        public TenantRepository()
        {
            Add(new Tenant
            {
                Birthday = new DateTime(1990, 6, 1),
                Debt = 50.5,
                IsDeleted = false,
                Name = "Ivanov Ivan"
            });
            Add(new Tenant
            {
                Birthday = new DateTime(1992, 4, 11),
                Debt = 350.5,
                IsDeleted = false,
                Name = "Ivanov1 Ivan1"
            });
            Add(new Tenant
            {
                Birthday = new DateTime(1978, 3, 23),
                Debt = 250.5,
                IsDeleted = true,
                Name = "Ivanov2 Ivan2"
            });
            Add(new Tenant
            {
                Birthday = new DateTime(1990, 6, 15),
                Debt = 150.5,
                IsDeleted = false,
                Name = "Ivanov3 Ivan3"
            });
        }
    }
}
