using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface IGameApplicationService
    {
        Task AddGameAsync(GameSubmissionDto gameSubmissionDto);
    }
}
