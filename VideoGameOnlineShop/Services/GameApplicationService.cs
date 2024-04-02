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

        public async Task<IEnumerable<GameApplicationViewModel>> GetAllGamesAsync()
        {
            IEnumerable<GameSubmissionDataModel> gameSubmissionDataModels = await _gameService.GetAllExistingGamesAsync();

            List<GameApplicationViewModel> gameApplicationViewModels = MapMultipleGameRecordToGameDataModel(gameSubmissionDataModels).ToList();

            return gameApplicationViewModels;

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

        public async Task DeleteSelectedGameAsync(Guid id)
        {
            await _gameService.DeleteSelectedGameAsync(id);
        }


        public IEnumerable<GameApplicationViewModel> MapMultipleGameRecordToGameDataModel(IEnumerable<GameSubmissionDataModel> gameSubmissionDataModels)
        {
            if (gameSubmissionDataModels is null || !gameSubmissionDataModels.Any())
            {
                return new List<GameApplicationViewModel>();
            }

            List<GameApplicationViewModel> newGameApplicationViewModels = new List<GameApplicationViewModel>();

            foreach (var gameDataModel in gameSubmissionDataModels)
            {
                newGameApplicationViewModels.Add(GameApplicationMapper.MapGameDataModelToGameViewModel(gameDataModel));
            }

            return newGameApplicationViewModels;

        }
    }
}
