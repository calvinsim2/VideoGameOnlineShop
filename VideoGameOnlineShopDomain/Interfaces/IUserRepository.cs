using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IUserRepository : IBaseGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool withTracking);
        Task<User?> GetUserByUsername(string username, bool withTracking);
    }
}
