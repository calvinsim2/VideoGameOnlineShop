using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopInfrastructure.Repositories.Common;

namespace VideoGameOnlineShopInfrastructure.Repositories
{
    public class GameRepository : BaseGenericRepository<Game>, IGameRepository
    {
        public GameRepository(VideoGameOnlineShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(bool withTracking)
        {
            IQueryable<Game> query = GetEntityQuery();

            IEnumerable<Game> result = await GetByListAsync(query, withTracking);

            return result;
        }

        public async Task<IEnumerable<Game>> GetGamesByDeveloperIdAsync(Guid developerId, bool withTracking)
        {
            IQueryable<Game> query = GetEntityQuery().Where(x => x.DeveloperId == developerId);

            IEnumerable<Game> result = await GetByListAsync(query, withTracking);

            return result;
        }

        public async Task<IEnumerable<Game>> GetGamesByCodeGenreAsync(string codeGenre, bool withTracking)
        {
            IQueryable<Game> query = GetEntityQuery().Where(x => x.CodeGenre == codeGenre);

            IEnumerable<Game> result = await GetByListAsync(query, withTracking);

            return result;
        }

        public async Task<IEnumerable<Game>> GetGamesBelowPriceThresholdAsync(decimal price, bool withTracking)
        {
            IQueryable<Game> query = GetEntityQuery().Where(x => x.Price <= price);

            IEnumerable<Game> result = await GetByListAsync(query, withTracking);

            return result;
        }
    }
}
