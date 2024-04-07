using Microsoft.EntityFrameworkCore;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopInfrastructure.EntityConfigurations;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.CodesTable;

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
        public DbSet<CodeDecodeMatureRating> CodeDecodeMatureRating { get; set; } = null!;
        public DbSet<CodeDecodeGenre> CodeDecodeGenre { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CodeDecodeMatureRatingConfiguation());
            modelBuilder.ApplyConfiguration(new CodeDecodeGenreConfiguration());
        }
    }
}
