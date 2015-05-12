using System;

namespace TenantsManager.Model
{
    public interface IRepositoryProvider : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IDomainObject;
        void SaveChanges();
    }
}
