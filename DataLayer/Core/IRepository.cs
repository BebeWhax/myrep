using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Core
{
    public interface IRepository<T> where T:class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(Guid Id);
        public Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);
        public Task CreateAsync(T item);
        public void Update(T item);
        public void Delete(T item);
    }
}
