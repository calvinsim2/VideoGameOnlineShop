using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Helpers.Developer;
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

        public async Task<DeveloperSubmissionDataModel> GetExplicitDeveloperAsync(Guid id)
        {
            Developer? developer = await _developerRepository.GetByIdAsync(id, false) ?? new Developer();

            DeveloperSubmissionDataModel developerSubmissionDataModel = DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developer);
            return developerSubmissionDataModel;
        }

        public async Task<IEnumerable<Developer>> GetAllExistingDevelopersAsync()
        {
            List<Developer> developers = (await _developerRepository.GetAllDevelopersAsync(false)).ToList();
            return developers;
        }

        public async Task AddDeveloperAsync(DeveloperSubmissionDataModel developerSubmissionDataModel)
        {
            Developer developer = DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developerSubmissionDataModel);

            await _developerRepository.AddAsync(developer);
            await _developerRepository.SaveChangesAsync();
        }
    }
}
