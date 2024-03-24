using VideoGameOnlineShopDomain.DomainModels;
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

        public async Task<Game?> GetExplicitDeveloperAsync(Guid id)
        {
            Game? game = await _gameRepository.GetByIdAsync(id, false);
            return game;
        }

        public async Task<IEnumerable<Game>> GetAllExistingGamesAsync()
        {
            List<Game> games = (await _gameRepository.GetAllGamesAsync(false)).ToList();
            return games;

        }

        public async Task AddGameAsync(Game game)
        {
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
    }
}
