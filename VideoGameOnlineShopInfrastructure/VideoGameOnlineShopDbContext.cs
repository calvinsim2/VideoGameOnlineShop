using Microsoft.EntityFrameworkCore;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopInfrastructure.EntityConfigurations;

namespace VideoGameOnlineShopInfrastructure
{
    public class VideoGameOnlineShopDbContext : DbContext
    {
        // to connect our db to .net core
        public VideoGameOnlineShopDbContext(DbContextOptions<VideoGameOnlineShopDbContext> options) : base(options)
        {

        }

        // Convert Models to DbSets, queries against this DbSet will be translated to queries against database.
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<Developer> Developer { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperEntityConfiguration());
        }
    }
}
