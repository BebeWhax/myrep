using DataLayer.Core;
using Entity;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<ClientEntity> ClientRepository
        {
            get
            {
                return _ClientRepository;
            }
        }

        public IRepository<DeveloperEntity> DeveloperRepository
        {
            get 
            {
                return _DeveloperRepository;
            }
        }

        public IRepository<PositionEntity> PositionRepository
        {
            get 
            { 
                return _PositionRepository; 
            }
        }

        public IRepository<ProjectEntity> ProjectRepository
        {
            get
            {
                return _ProjectRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private AppContext _context;
        private IRepository<ClientEntity> _ClientRepository;
        private IRepository<DeveloperEntity> _DeveloperRepository;
        private IRepository<PositionEntity> _PositionRepository;
        private IRepository<ProjectEntity> _ProjectRepository;
        public UnitOfWork(
            AppContext context,
            IRepository<ClientEntity> clientRepository,
            IRepository<DeveloperEntity> developerRepository,
            IRepository<PositionEntity> positionRepository,
            IRepository<ProjectEntity> projectRepository)
        {
            _context = context;
            _ClientRepository = clientRepository;
            _DeveloperRepository = developerRepository;
            _PositionRepository = positionRepository;
            _ProjectRepository = projectRepository;

        }
    }
}
