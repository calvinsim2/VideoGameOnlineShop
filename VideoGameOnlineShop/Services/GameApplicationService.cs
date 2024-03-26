using VideoGameOnlineShopApplication.Helpers.Game;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;
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

        public async Task<GameApplicationViewModel> GetExplicitGameAsync(Guid id)
        {
            GameSubmissionDataModel gameSubmissionDataModel = await _gameService.GetExplicitGameAsync(id);

            GameApplicationViewModel gameApplicationViewModel = GameApplicationMapper.MapGameDataModelToGameViewModel(gameSubmissionDataModel);
            return gameApplicationViewModel;
        }

        public async Task AddGameAsync(GameSubmissionDto gameSubmissionDto)
        {
            GameSubmissionDataModel gameSubmissionDataModel = GameApplicationMapper.MapGameDtoToGameDataModel(gameSubmissionDto);
            await _gameService.AddGameAsync(gameSubmissionDataModel);
        }
    }
}
