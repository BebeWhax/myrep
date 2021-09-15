using BLL.Core;
using DataLayer.Core;
using Domain;
using Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DeveloperService : IDeveloperService
    {
        IUnitOfWork unitOfWork;

        public DeveloperService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DeveloperDTO developer)
        {
            await unitOfWork.DeveloperRepository.CreateAsync(developer.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DeveloperModel>> FindAsync(DeveloperDTO developerFilter)
        {
            var result = await unitOfWork.DeveloperRepository
                .FindAsync(p =>
                !string.IsNullOrEmpty(developerFilter.Name) ? p.Name.Contains(developerFilter.Name) : true
                && (developerFilter.PositionId != Guid.Empty) ? p.PositionId == developerFilter.PositionId : true);
            return result.ToDTO().ToModel();
        }

        public async Task<IEnumerable<DeveloperModel>> FindDevelopersOnProjectAsync(Guid projectId)
        {
            var result = await unitOfWork.ProjectRepository.GetAsync(projectId);
            return result.Developers.ToDTO().ToModel();
        }

        public async Task<IEnumerable<DeveloperModel>> GetAllAsync()
        {
            var result = await unitOfWork.DeveloperRepository.GetAllAsync();
            return result.ToDTO().ToModel();
        }

        public async Task<DeveloperModel> GetAsync(Guid id)
        {
            var result=await unitOfWork.DeveloperRepository.GetAsync(id);
            return result.ToDTO().ToModel();
        }

        public async Task RemoveAsync(DeveloperDTO developer)
        {
            unitOfWork.DeveloperRepository.Delete(developer.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(DeveloperDTO developer)
        {
            unitOfWork.DeveloperRepository.Update(developer.ToEntity());
            await unitOfWork.SaveAsync();
        }
    }
}
