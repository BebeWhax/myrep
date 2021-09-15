using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public AppContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
