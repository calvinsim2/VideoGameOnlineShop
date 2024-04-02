using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IGameService
    {
        Task<GameDataModel> GetExplicitGameAsync(Guid id);
        Task<IEnumerable<GameDataModel>> GetAllExistingGamesAsync();
        Task AddGameAsync(GameDataModel gameSubmissionDataModel);
        Task UpdateSelectedGameAsync(GameDataModel gameDataModel);
        Task DeleteSelectedGameAsync(Guid id);
    }
}
