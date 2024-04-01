using VideoGameOnlineShopApplication.Helpers.Developer;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopApplication.Services
{
    public class DeveloperApplicationService : IDeveloperApplicationService
    {
        private readonly IDeveloperService _developerService;

        public DeveloperApplicationService(IDeveloperService developerService) 
        {
            _developerService = developerService;
        }

        public async Task<DeveloperApplicationViewModel> GetExplicitDeveloperAsync(Guid id)
        {
            DeveloperSubmissionDataModel developerDataModel = await _developerService.GetExplicitDeveloperAsync(id);

            DeveloperApplicationViewModel developerApplicationViewModel = DeveloperApplicationMapper.MapDeveloperDataModelToDeveloperViewModel(developerDataModel);

            return developerApplicationViewModel;
        }

        public async Task AddDeveloperAsync(DeveloperSubmissionDto developerSubmissionDto)
        {
            DeveloperSubmissionDataModel developerSubmissionDataModel = DeveloperApplicationMapper.MapDeveloperDtoToDeveloperDataModel(developerSubmissionDto);
            await _developerService.AddDeveloperAsync(developerSubmissionDataModel);
        }
    }
}
