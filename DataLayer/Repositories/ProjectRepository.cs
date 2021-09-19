using DataLayer.Core;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataLayer.Repositories
{
    public class ProjectRepository : BaseRepository<ProjectEntity>
    {
        public ProjectRepository(AppContext context):base(context)
        {

        }
        public override async Task CreateAsync(ProjectEntity item)
        {
            await _context.Projects.AddAsync(item);
        }

        public override void Delete(ProjectEntity item)
        {
            _context.Projects.Remove(item);
        }

        public override async Task<IEnumerable<ProjectEntity>> FindAsync(Func<ProjectEntity, bool> predicate)
        {
            IQueryable<ProjectEntity> projects = _context.Projects.AsNoTracking().Include(x=>x.Client).Include(x=>x.Developers);
            var result = projects.Where(predicate).ToList();
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _context.Projects.AsNoTracking().Include(x => x.Client).Include(x => x.Developers).ToListAsync();
        }

        public override async Task<ProjectEntity> GetAsync(Guid Id)
        {
            IQueryable<ProjectEntity> projects = _context.Projects.AsNoTracking().Include(x => x.Client).Include(x => x.Developers).ThenInclude(i=>i.Position);
            var result = await projects.FirstAsync(p => p.Id == Id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public override void Update(ProjectEntity item)
        {

            var entity = _context.Projects.Include(i => i.Developers).ThenInclude(i => i.Position).First(p => p.Id == item.Id);


            var developers = _context.Developers.AsEnumerable().Where(p => item.Developers.Any(pp => pp.Id == p.Id));

            var added = developers?.Except(entity.Developers);
            var removed = entity.Developers?.Except(developers);
            
            foreach (var t in added)
                entity.Developers.Add(t);
            foreach (var t in removed.ToList())
                entity.Developers.Remove(t);
            
            entity.ClientId = item.ClientId;
            entity.Client = item.Client;
            entity.Name = item.Name;
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Projects.Update(entity);
        }
    }
}
