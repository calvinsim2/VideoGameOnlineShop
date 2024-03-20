using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopInfrastructure.Repositories.Common;

namespace VideoGameOnlineShopInfrastructure.Repositories
{
    public class DeveloperRepository : BaseGenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(VideoGameOnlineShopDbContext dbContext) : base(dbContext) 
        { 
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync(bool withTracking)
        {
            IQueryable<Developer> query = GetEntityQuery();

            IEnumerable<Developer> result = await GetByListAsync(query, withTracking);

            return result;
        }

        public async Task<Developer?> GetByNameAsync(string name, bool withTracking)
        {
            IQueryable<Developer> query = GetEntityQuery().Where(x => x.Name == name);

            Developer? developer = await GetByFirstOrDefaultAsync(query, withTracking);

            return developer;
        }
    }
}