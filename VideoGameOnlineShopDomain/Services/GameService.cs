using System.Net;
using System.Net.Mail;
using System.Web.Http;
using System.Xml.Linq;
using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Helpers.Game;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Services
{
    public class GameService : IGameService
    {
        public readonly IGameRepository _gameRepository;
        public readonly IDeveloperRepository _developerRepository;
        private readonly ICommonUtilityMethods _commonUtilityMethods;

        public GameService(IGameRepository gameRepository,
                           IDeveloperRepository developerRepository,
                           ICommonUtilityMethods commonUtilityMethods) 
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _commonUtilityMethods = commonUtilityMethods;
        }

        public async Task<GameDataModel> GetExplicitGameAsync(Guid id)
        {
            Game? game = await _gameRepository.GetByIdAsync(id, false) ?? throw new HttpRequestException("Game not found", null, HttpStatusCode.NotFound);

            GameDataModel gameSubmissionDataModel = GameDomainMapper.MapGameToGameDataModel(game);
            return gameSubmissionDataModel;
        }

        public async Task<IEnumerable<GameDataModel>> GetAllExistingGamesAsync()
        {
            IEnumerable<Game> games = (await _gameRepository.GetAllGamesAsync(false)).ToList();

            List<GameDataModel> gameSubmissionDataModels = MapMultipleGameRecordToGameDataModel(games).ToList();
            return gameSubmissionDataModels;

        }

        public async Task AddGameAsync(GameDataModel gameSubmissionDataModel)
        {
            bool gameNameExist = await CheckGameNameAlreadyExistAsync(gameSubmissionDataModel.Name);

            if (gameNameExist) 
            {
                throw new BadRequestException("Game Name already exists");
            }

            Game game = GameDomainMapper.MapGameDtoToGameDataModel(gameSubmissionDataModel);
            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task UpdateSelectedGameAsync(GameDataModel gameDataModel)
        {
            Game? game = await _gameRepository.GetByIdAsync(gameDataModel.Id, false)
                                    ?? throw new NotFoundException("Game not found");

            MapIncomingDataToExistingGameForUpdate(gameDataModel, game);

            _gameRepository.Update(game);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task DeleteSelectedGameAsync(Guid id)
        {
            var existingGame = await _gameRepository.GetByIdAsync(id, true);
            if (existingGame is null)
            {
                throw new HttpRequestException("Game not found", null, HttpStatusCode.NotFound);
            }

            _gameRepository.Remove(existingGame);
            await _gameRepository.SaveChangesAsync();
        }

        public async Task<bool> CheckGameNameAlreadyExistAsync(string name)
        {
            List<Game> games = (await _gameRepository.GetAllGamesAsync(false)).ToList();

            foreach (Game game in games) 
            {
                string existingGameName = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(game.Name);
                string inputGameName = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(name);

                if (existingGameName == inputGameName)
                {
                    return true;
                }
            }

            return false;
        }

        #region Common Non Repository calls functions

        public IEnumerable<GameDataModel> MapMultipleGameRecordToGameDataModel(IEnumerable<Game> games)
        {
            if (games is null || !games.Any())
            {
                return new List<GameDataModel>();
            }

            List<GameDataModel> newGameSubmissionDataModels = new List<GameDataModel>();

            foreach (var game in games)
            {
                newGameSubmissionDataModels.Add(GameDomainMapper.MapGameToGameDataModel(game));
            }

            return newGameSubmissionDataModels;

        }

        public static void MapIncomingDataToExistingGameForUpdate(GameDataModel incomingGameDataModel, Game existingGame)
        {
            existingGame.Name = incomingGameDataModel.Name;
            existingGame.Description = incomingGameDataModel.Description;
            existingGame.CodeMatureRating = incomingGameDataModel.CodeMatureRating;
            existingGame.Price = incomingGameDataModel.Price;
            existingGame.ImageUrl = incomingGameDataModel.ImageUrl;
            existingGame.DeveloperId = incomingGameDataModel.DeveloperId;
            existingGame.CodeGenre = incomingGameDataModel.CodeGenre;
            existingGame.DateTimeUpdated = DateTimeOffset.Now;
        }

        #endregion
    }
}
