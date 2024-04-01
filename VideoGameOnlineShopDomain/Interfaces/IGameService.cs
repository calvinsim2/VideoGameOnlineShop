using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IGameService
    {
        Task<GameSubmissionDataModel> GetExplicitGameAsync(Guid id);
        Task<IEnumerable<GameSubmissionDataModel>> GetAllExistingGamesAsync();
        Task AddGameAsync(GameSubmissionDataModel gameSubmissionDataModel);
        Task DeleteSelectedGameAsync(Guid id);
    }
}
