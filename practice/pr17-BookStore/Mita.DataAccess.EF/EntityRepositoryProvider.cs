using System;
using System.Data.Entity;
using System.Linq;

namespace Mita.DataAccess.EF
{
    public class EntityRepositoryProvider<TDbContext> : IRepositoryProvider
        where TDbContext : DbContext, new()
    {
        private readonly TDbContext _dbContext;
        private bool _isDisposed = false;

        public EntityRepositoryProvider()
        {
            _dbContext = new TDbContext();
        }

        public IRepository<T> GetRepository<T>() where T : class, IDomainObject
        {
            if (!_isDisposed)  
            {
                var repository = new EntityRepository<T>(_dbContext);
                return repository;
            }

            throw new ObjectDisposedException(GetType().Name);
        }

        public void SaveChanges()
        {
            if (!_isDisposed)
            {
                _dbContext.SaveChanges(); 
                return;
            }

            throw new ObjectDisposedException(GetType().Name);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _dbContext.Dispose();
                _isDisposed = true;
            }
        }

        public void RevertChanges()
        {
            var changedEntries = _dbContext.ChangeTracker
                .Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }
    }
}
