using BLL.Core;
using DataLayer.Core;
using Domain;
using Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProjectService : IProjectService
    {
        IUnitOfWork unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ProjectDTO project)
        {
            await unitOfWork.ProjectRepository.CreateAsync(project.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ProjectModel>> FindAsync(ProjectDTO projectFilter)
        {
            var result = await unitOfWork.ProjectRepository.FindAsync(p =>
                 !string.IsNullOrEmpty(projectFilter.Name) ? p.Name.Contains(projectFilter.Name) : true
                 && (projectFilter.ClientId != Guid.Empty) ? p.ClientId == projectFilter.ClientId:true);
            return result.ToDTO().ToModel();
        }

        public async Task<IEnumerable<ProjectModel>> FindDeveloperProjectsAsync(Guid developerId)
        {
            var result = await unitOfWork.DeveloperRepository.GetAsync(developerId);
            return result.Projects.ToDTO().ToModel();
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            var result = await unitOfWork.ProjectRepository.GetAllAsync();
            return result.ToDTO().ToModel();
        }

        public async Task<ProjectModel> GetAsync(Guid id)
        {
            var result = await unitOfWork.ProjectRepository.GetAsync(id);
            return result.ToDTO().ToModel();
        }

        public async Task RemoveAsync(ProjectDTO project)
        {
            unitOfWork.ProjectRepository.Delete(project.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ProjectDTO project)
        {
            unitOfWork.ProjectRepository.Update(project.ToEntity());
            await unitOfWork.SaveAsync();
        }
    }
}
