using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopDomain.Services
{
    public class DeveloperService : IDeveloperService
    {
        public readonly IGameRepository _gameRepository;
        public readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IGameRepository gameRepository,
                                IDeveloperRepository developerRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
        }

        public async Task<Developer?> GetExplicitDeveloperAsync(Guid id)
        {
            Developer? developers = await _developerRepository.GetByIdAsync(id, false);
            return developers;
        }

        public async Task<IEnumerable<Developer>> GetAllExistingDevelopersAsync()
        {
            List<Developer> developers = (await _developerRepository.GetAllDevelopersAsync(false)).ToList();
            return developers;

        }
    }
}
