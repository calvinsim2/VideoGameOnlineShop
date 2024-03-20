using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IGameService
    {
        Task<Game?> GetExplicitDeveloperAsync(Guid id);
        Task<IEnumerable<Game>> GetAllExistingGamesAsync();
        Task AddGameAsync(Game game);
        Task DeleteSelectedGameAsync(Guid id);
    }
}
