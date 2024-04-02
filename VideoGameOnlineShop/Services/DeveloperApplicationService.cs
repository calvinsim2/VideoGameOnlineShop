using System.Net;
using VideoGameOnlineShopApplication.Helpers.Developer;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Services
{
    public class DeveloperApplicationService : IDeveloperApplicationService
    {
        private readonly IDeveloperService _developerService;
        private readonly ICommonUtilityMethods _commonUtilityMethods;

        public DeveloperApplicationService(IDeveloperService developerService,
                                           ICommonUtilityMethods commonUtilityMethods) 
        {
            _developerService = developerService;
            _commonUtilityMethods = commonUtilityMethods;
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

        public async Task DeleteSelectedDeveloperAsync(Guid id)
        {
            await _developerService.DeleteSelectedDeveloperAsync(id);
        }

    }
}
