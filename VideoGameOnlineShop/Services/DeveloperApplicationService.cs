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

        public async Task<IEnumerable<DeveloperApplicationViewModel>> GetAllDevelopersAsync()
        {
            IEnumerable<DeveloperDataModel> developerDataModels = await _developerService.GetAllExistingDevelopersAsync();

            IEnumerable<DeveloperApplicationViewModel> developerViewModels = MapMultipleDeveloperDataModelRecordToDeveloperViewModel(developerDataModels);

            return developerViewModels;
        }

        public async Task<DeveloperApplicationViewModel> GetExplicitDeveloperAsync(Guid id)
        {
            DeveloperDataModel developerDataModel = await _developerService.GetExplicitDeveloperAsync(id);

            DeveloperApplicationViewModel developerApplicationViewModel = DeveloperApplicationMapper.MapDeveloperDataModelToDeveloperViewModel(developerDataModel);

            return developerApplicationViewModel;
        }

        public async Task AddDeveloperAsync(DeveloperSubmissionDto developerSubmissionDto)
        {
            DeveloperDataModel developerSubmissionDataModel = DeveloperApplicationMapper.MapDeveloperDtoToDeveloperDataModel(developerSubmissionDto);
            await _developerService.AddDeveloperAsync(developerSubmissionDataModel);
        }

        public async Task UpdateSelectedDeveloperAsync(DeveloperUpdateDto developerUpdateDto)
        {
            DeveloperDataModel developerUpdateDataModel = DeveloperApplicationMapper.MapDeveloperUpdateDtoToDeveloperDataModel(developerUpdateDto);
            await _developerService.UpdateSelectedDeveloperAsync(developerUpdateDataModel);
        }

        public async Task DeleteSelectedDeveloperAsync(Guid id)
        {
            await _developerService.DeleteSelectedDeveloperAsync(id);
        }

        #region Common Non Domain call Methods

        public IEnumerable<DeveloperApplicationViewModel> MapMultipleDeveloperDataModelRecordToDeveloperViewModel(IEnumerable<DeveloperDataModel> developerDataModels)
        {
            if (developerDataModels is null || !developerDataModels.Any())
            {
                return new List<DeveloperApplicationViewModel>();
            }

            List<DeveloperApplicationViewModel> newDeveloperApplicationViewModels = new List<DeveloperApplicationViewModel>();

            foreach (var developerDataModel in developerDataModels)
            {
                newDeveloperApplicationViewModels.Add(DeveloperApplicationMapper.MapDeveloperDataModelToDeveloperViewModel(developerDataModel));
            }

            return newDeveloperApplicationViewModels;

        }

        #endregion
    }
}
