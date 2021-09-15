using DataLayer.Core;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PositionRepository : BaseRepository<PositionEntity>
    {
        public PositionRepository(AppContext context):base(context)
        {

        }
        public override async Task CreateAsync(PositionEntity item)
        {
            await _context.Positions.AddAsync(item);
        }

        public override void Delete(PositionEntity item)
        {
            _context.Positions.Remove(item);
        }

        public override async Task<IEnumerable<PositionEntity>> FindAsync(Func<PositionEntity, bool> predicate)
        {
            IQueryable<PositionEntity> positions = _context.Positions.AsNoTracking();
            var result = positions.Where(predicate).ToList();
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<PositionEntity>> GetAllAsync()
        {
            return await _context.Positions.AsNoTracking().ToListAsync();
        }

        public override async Task<PositionEntity> GetAsync(Guid Id)
        {
            var result = await _context.Positions.FindAsync(Id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public override void Update(PositionEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
