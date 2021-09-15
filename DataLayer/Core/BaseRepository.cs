using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Core
{
    public abstract class BaseRepository<T> : IRepository<T> where T:class
    {
        protected AppContext _context;
        public BaseRepository(AppContext context)
        {
            _context = context;
        }

        public abstract Task CreateAsync(T item);

        public abstract void Delete(T item);

        public abstract Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetAsync(Guid Id);

        public abstract void Update(T item);
    }
}
