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
            IEnumerable<GameDataModel> gameSubmissionDataModels = await _gameService.GetAllExistingGamesAsync();

            List<GameApplicationViewModel> gameApplicationViewModels = MapMultipleGameDataModelRecordToGameViewModel(gameSubmissionDataModels).ToList();

            return gameApplicationViewModels;

        }

        public async Task<GameApplicationViewModel> GetExplicitGameAsync(Guid id)
        {
            GameDataModel gameSubmissionDataModel = await _gameService.GetExplicitGameAsync(id);

            GameApplicationViewModel gameApplicationViewModel = GameApplicationMapper.MapGameDataModelToGameViewModel(gameSubmissionDataModel);
            return gameApplicationViewModel;
        }

        public async Task AddGameAsync(GameSubmissionDto gameSubmissionDto)
        {
            GameDataModel gameSubmissionDataModel = GameApplicationMapper.MapGameSubmissionDtoToGameDataModel(gameSubmissionDto);
            await _gameService.AddGameAsync(gameSubmissionDataModel);
        }

        public async Task UpdateSelectedGameAsync(GameUpdateDto gameUpdateDto)
        {
            GameDataModel gameSubmissionDataModel = GameApplicationMapper.MapGameUpdateDtoToGameDataModel(gameUpdateDto);
            await _gameService.UpdateSelectedGameAsync(gameSubmissionDataModel);
        }

        public async Task DeleteSelectedGameAsync(Guid id)
        {
            await _gameService.DeleteSelectedGameAsync(id);
        }

        public IEnumerable<GameApplicationViewModel> MapMultipleGameDataModelRecordToGameViewModel(IEnumerable<GameDataModel> gameSubmissionDataModels)
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
