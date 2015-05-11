using System.Data.Entity;

namespace TenantsManager.Model
{
    public class TenantsContext : DbContext
    {
        public TenantsContext()
            : base("TenantsConnection") { }

        public IDbSet<Tenant> Tenants { get; set; }
    }
}
