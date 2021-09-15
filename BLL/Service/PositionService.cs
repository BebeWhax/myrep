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
    public class PositionService : IPositionService
    {
        IUnitOfWork unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PositionDTO position)
        {
            await unitOfWork.PositionRepository.CreateAsync(position.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PositionModel>> FindAsync(PositionDTO positionFilter)
        {
            var result = await unitOfWork.PositionRepository.
                FindAsync(p => 
                !string.IsNullOrEmpty(positionFilter.Name) ? p.Name.Contains(positionFilter.Name) : true);

            return result.ToDTO().ToModel();
        }

        public async Task<IEnumerable<PositionModel>> GetAllAsync()
        {
            var result = await unitOfWork.PositionRepository.GetAllAsync();
            return result.ToDTO().ToModel();
        }

        public async Task<PositionModel> GetAsync(Guid id)
        {
            var result = await unitOfWork.PositionRepository.GetAsync(id);
            return result.ToDTO().ToModel();
        }

        public async Task RemoveAsync(PositionDTO position)
        {
            unitOfWork.PositionRepository.Delete(position.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(PositionDTO position)
        {
            unitOfWork.PositionRepository.Update(position.ToEntity());
            await unitOfWork.SaveAsync();
        }
    }
}
