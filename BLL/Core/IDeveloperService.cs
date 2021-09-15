using Domain;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Core
{
    public interface IDeveloperService
    {
        public Task AddAsync(DeveloperDTO developer);
        public Task RemoveAsync(DeveloperDTO developer);
        public Task<IEnumerable<DeveloperModel>> FindAsync(DeveloperDTO developerFilter);
        public Task UpdateAsync(DeveloperDTO developer);
        public Task<IEnumerable<DeveloperModel>> FindDevelopersOnProjectAsync(Guid projectId);
        public Task<IEnumerable<DeveloperModel>> GetAllAsync();
        public Task<DeveloperModel> GetAsync(Guid id);
    }
}
