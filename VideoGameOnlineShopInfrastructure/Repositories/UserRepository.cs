using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopInfrastructure.Repositories.Common;

namespace VideoGameOnlineShopInfrastructure.Repositories
{
    public class UserRepository : BaseGenericRepository<User>, IUserRepository
    {
        public UserRepository(VideoGameOnlineShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool withTracking)
        {
            IQueryable<User> query = GetEntityQuery();

            IEnumerable<User> result = await GetByListAsync(query, withTracking);

            return result;
        }

        public async Task<User?> GetUserByUsername(string username, bool withTracking)
        {
            IQueryable<User> query = GetEntityQuery().Where(x => x.Username == username);

            User? user = await GetByFirstOrDefaultAsync(query, withTracking);

            return user;
        }
    }
}
