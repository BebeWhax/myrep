using Domain;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Core
{
    public interface IPositionService
    {
        public Task AddAsync(PositionDTO position);
        public Task RemoveAsync(PositionDTO position);
        public Task<IEnumerable<PositionModel>> FindAsync(PositionDTO positionFilter);
        public Task UpdateAsync(PositionDTO position);
        public Task<IEnumerable<PositionModel>> GetAllAsync();
        public Task<PositionModel> GetAsync(Guid id);
    }
}
