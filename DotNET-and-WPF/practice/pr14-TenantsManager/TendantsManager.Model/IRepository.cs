using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsManager.Model
{
    public interface IRepository<TItem> where TItem : class, IDomainObject 
    {
        void Add(TItem item);
        void Remove(TItem item);
        TItem Find(int id);
        IEnumerable<TItem> GetAll();
    }
}
