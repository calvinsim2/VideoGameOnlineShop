using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopApplication.Helpers.Developer
{
    public class DeveloperApplicationMapper
    {
        public static DeveloperSubmissionDataModel MapDeveloperDtoToDeveloperDataModel(DeveloperSubmissionDto developerSubmissionDto)
        {
            DeveloperSubmissionDataModel developerSubmissionDataModel = new DeveloperSubmissionDataModel
            {
                Name = developerSubmissionDto.Name,
                Slogan = developerSubmissionDto.Slogan,
                Logo = developerSubmissionDto.Logo,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now,
            };

            return developerSubmissionDataModel;
        }

        public static DeveloperApplicationViewModel MapDeveloperDataModelToDeveloperViewModel(DeveloperSubmissionDataModel developerSubmissionDataModel)
        {
            DeveloperApplicationViewModel developerSubmissionViewModel = new DeveloperApplicationViewModel
            {
                Id = developerSubmissionDataModel.Id,
                Name = developerSubmissionDataModel.Name,
                Slogan = developerSubmissionDataModel.Slogan,
                Logo = developerSubmissionDataModel.Logo,
                DateTimeCreated = developerSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = developerSubmissionDataModel.DateTimeUpdated,
            };

            return developerSubmissionViewModel;
        }
    }
}
