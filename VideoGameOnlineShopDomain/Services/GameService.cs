using System.Collections.Generic;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Helpers.Game;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopDomain.Services
{
    public class GameService : IGameService
    {
        public readonly IGameRepository _gameRepository;
        public readonly IDeveloperRepository _developerRepository;

        public GameService(IGameRepository gameRepository,
                           IDeveloperRepository developerRepository) 
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
        }

        public async Task<GameSubmissionDataModel> GetExplicitGameAsync(Guid id)
        {
            Game? game = await _gameRepository.GetByIdAsync(id, false) ?? new Game();

            GameSubmissionDataModel gameSubmissionDataModel = GameDomainMapper.MapGameToGameDataModel(game);
            return gameSubmissionDataModel;
        }

        public async Task<IEnumerable<GameSubmissionDataModel>> GetAllExistingGamesAsync()
        {
            IEnumerable<Game> games = (await _gameRepository.GetAllGamesAsync(false)).ToList();

            List<GameSubmissionDataModel> gameSubmissionDataModels = MapMultipleGameRecordToGameDataModel(games).ToList();
            return gameSubmissionDataModels;

        }

        public async Task AddGameAsync(GameSubmissionDataModel gameSubmissionDataModel)
        {
            Game game = GameDomainMapper.MapGameDtoToGameDataModel(gameSubmissionDataModel);
            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task DeleteSelectedGameAsync(Guid id)
        {
            var existingGame = await _gameRepository.GetByIdAsync(id, true);
            if (existingGame is null)
            {
                return;
            }

            _gameRepository.Remove(existingGame);
            await _gameRepository.SaveChangesAsync();
        }

        public IEnumerable<GameSubmissionDataModel> MapMultipleGameRecordToGameDataModel(IEnumerable<Game> games)
        {
            if (games is null || !games.Any())
            {
                return new List<GameSubmissionDataModel>();
            }

            List<GameSubmissionDataModel> newGameSubmissionDataModels = new List<GameSubmissionDataModel>();

            foreach (var game in games)
            {
                newGameSubmissionDataModels.Add(GameDomainMapper.MapGameToGameDataModel(game));
            }

            return newGameSubmissionDataModels;

        }
    }
}
