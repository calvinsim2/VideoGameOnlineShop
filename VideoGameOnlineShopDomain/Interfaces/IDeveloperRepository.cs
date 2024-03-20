using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IDeveloperRepository : IBaseGenericRepository<Developer>
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync(bool withTracking);
        Task<Developer?> GetByNameAsync(string name, bool withTracking);
    }
}
