using Entity;
using System.Threading.Tasks;

namespace DataLayer.Core
{
    public interface IUnitOfWork
    {
        public IRepository<ClientEntity> ClientRepository { get; }
        public IRepository<DeveloperEntity> DeveloperRepository { get; }
        public IRepository<PositionEntity> PositionRepository { get; }
        public IRepository<ProjectEntity> ProjectRepository { get; }
        public Task SaveAsync();
    }
}
