using DataLayer.Core;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class DeveloperRepository : BaseRepository<DeveloperEntity>
    {
        public DeveloperRepository(AppContext context):base(context)
        {

        }
        public override async Task CreateAsync(DeveloperEntity item)
        {
            await _context.AddAsync(item);
        }

        public override void Delete(DeveloperEntity item)
        {
            _context.Developers.Remove(item);
        }

        public override async Task<IEnumerable<DeveloperEntity>> FindAsync(Func<DeveloperEntity, bool> predicate)
        {
            IQueryable<DeveloperEntity> developers = _context.Developers.AsNoTracking().Include(i=>i.Projects).Include(i=>i.Position);
            var result = developers.Where(predicate).ToList();
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<DeveloperEntity>> GetAllAsync()
        {
            return await _context.Developers.AsNoTracking().Include(i => i.Projects).Include(i => i.Position).ToListAsync();
        }

        public override async Task<DeveloperEntity> GetAsync(Guid Id)
        {
            var developers = _context.Developers.AsNoTracking().Include(i => i.Projects).Include(i=>i.Position);
            var result = await developers.FirstAsync(p => p.Id == Id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public override void Update(DeveloperEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
