using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface IGameApplicationService
    {
        Task<IEnumerable<GameApplicationViewModel>> GetAllGamesAsync();
        Task<GameApplicationViewModel> GetExplicitGameAsync(Guid id);
        Task AddGameAsync(GameSubmissionDto gameSubmissionDto);
        Task UpdateSelectedGameAsync(GameUpdateDto gameUpdateDto);
        Task DeleteSelectedGameAsync(Guid id);
    }
}
