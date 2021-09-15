using Domain;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Core
{
    public interface IClientService
    {
        public Task AddAsync(ClientDTO client);
        public Task RemoveAsync(ClientDTO client);
        public Task<IEnumerable<ClientModel>> FindAsync(ClientDTO clientFilter);
        public Task UpdateAsync(ClientDTO client);
        public Task<IEnumerable<ClientModel>> GetAllAsync();
        public Task<ClientModel> GetAsync(Guid id);
    }
}
