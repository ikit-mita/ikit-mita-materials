using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsManager.Model;

namespace TenantsManager
{
    public class MainViewModel
    {
        private TenantRepository _repository = new TenantRepository();

        public ICollection<Tenant> Tenands { get; set; }

        public Tenant SelectedTenant { get; set; }

        public MainViewModel()
        {
            Tenands = _repository.GetAll().ToArray();
        }
    }
}
