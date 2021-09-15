using DataLayer.Core;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ClientRepository:BaseRepository<ClientEntity>
    {
        public ClientRepository(AppContext context):base(context)
        {

        }

        public override async Task CreateAsync(ClientEntity item)
        {
            await _context.Clients.AddAsync(item);
        }

        public override void Delete(ClientEntity item)
        {
            _context.Clients.Remove(item);    
        }

        public override async Task<IEnumerable<ClientEntity>> FindAsync(Func<ClientEntity, bool> predicate)
        {
            IQueryable<ClientEntity> clients = _context.Clients.AsNoTracking();
            var result=clients.Where(predicate).ToList();
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<ClientEntity>> GetAllAsync()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public override async Task<ClientEntity> GetAsync(Guid Id)
        {
            var result = await _context.Clients.FindAsync(Id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public override void Update(ClientEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
