using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IGameService
    {
        Task<GameSubmissionDataModel> GetExplicitGameAsync(Guid id);
        Task<IEnumerable<Game>> GetAllExistingGamesAsync();
        Task AddGameAsync(GameSubmissionDataModel gameSubmissionDataModel);
        Task DeleteSelectedGameAsync(Guid id);
    }
}
