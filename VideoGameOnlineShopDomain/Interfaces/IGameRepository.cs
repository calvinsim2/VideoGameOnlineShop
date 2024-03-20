using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IGameRepository : IBaseGenericRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesAsync(bool withTracking);
        Task<IEnumerable<Game>> GetGamesByDeveloperIdAsync(Guid developerId, bool withTracking);
        Task<IEnumerable<Game>> GetGamesByCodeGenreAsync(string codeGenre, bool withTracking);
        Task<IEnumerable<Game>> GetGamesBelowPriceThresholdAsync(decimal price, bool withTracking);
    }
}
