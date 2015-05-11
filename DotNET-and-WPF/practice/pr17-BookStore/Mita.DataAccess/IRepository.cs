using System.Linq;

namespace Mita.DataAccess
{
    public interface IRepository<TItem> where TItem : class, IDomainObject 
    {
        void Add(TItem item);
        void Remove(TItem item);
        TItem Find(int id);
        IQueryable<TItem> GetAll();
    }
}
