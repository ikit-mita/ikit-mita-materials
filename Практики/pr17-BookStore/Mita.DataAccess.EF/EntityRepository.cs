using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mita.DataAccess.EF
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly DbContext _dbContext;

        public EntityRepository(DbContext db)
        {
            _dbContext = db;
        }

        public void Add(T item)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Add(item);
        }

        public void Remove(T item)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Remove(item);
        }

        public T Find(int id)
        {
            var dbSet = _dbContext.Set<T>();
            var item = dbSet.Find(id);
            return item;
        }

        public IQueryable<T> GetAll()
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet;
        }
    }
}
