using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopApplication.Services
{
    public class GameApplicationService : IGameApplicationService
    {
        private readonly IGameService _gameService;

        public GameApplicationService(IGameService gameService) 
        {
            _gameService = gameService;
        }

        public async Task AddGameAsync(GameSubmissionDto gameSubmissionDto)
        {

        }
    }
}
