using Domain;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Core
{
    public interface IProjectService
    {
        public Task AddAsync(ProjectDTO project);
        public Task RemoveAsync(ProjectDTO project);
        public Task<IEnumerable<ProjectModel>> FindAsync(ProjectDTO projectFilter);
        public Task UpdateAsync(ProjectDTO project);
        public Task<IEnumerable<ProjectModel>> FindDeveloperProjectsAsync(Guid developerId);
        public Task<IEnumerable<ProjectModel>> GetAllAsync();
        public Task<ProjectModel> GetAsync(Guid id);
    }
}
