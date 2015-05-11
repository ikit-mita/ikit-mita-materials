using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySample
{
    public class MemoryRepository<TItem> : IRepository<TItem> where TItem : IDomainObject
    {
        private Dictionary<int, TItem> _storage = new Dictionary<int, TItem>();

        public void Add(TItem item)
        {
            int newKey = _storage.Keys
                .DefaultIfEmpty()
                .Max() + 1;

            item.Id = newKey;

            _storage[newKey] = item;
        }

        public void Remove(TItem item)
        {
            _storage.Remove(item.Id);
        }

        public TItem Find(int id)
        {
            if (_storage.ContainsKey(id))
            {
                var item = _storage[id];
                return item;
            }

            return default(TItem);
        }

        public IEnumerable<TItem> GetAll()
        {
            return _storage.Values;
        }
    }
}
