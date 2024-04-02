using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopApplication.Helpers.Developer
{
    public class DeveloperApplicationMapper
    {
        public static DeveloperDataModel MapDeveloperDtoToDeveloperDataModel(DeveloperSubmissionDto developerSubmissionDto)
        {
            DeveloperDataModel developerSubmissionDataModel = new DeveloperDataModel
            {
                Name = developerSubmissionDto.Name,
                Slogan = developerSubmissionDto.Slogan,
                Logo = developerSubmissionDto.Logo,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now,
            };

            return developerSubmissionDataModel;
        }

        public static DeveloperDataModel MapDeveloperUpdateDtoToDeveloperDataModel(DeveloperUpdateDto developerUpdateDto)
        {
            DeveloperDataModel developerSubmissionDataModel = new DeveloperDataModel
            {
                Id = Guid.Parse(developerUpdateDto.Id),
                Name = developerUpdateDto.Name,
                Slogan = developerUpdateDto.Slogan,
                Logo = developerUpdateDto.Logo,
            };

            return developerSubmissionDataModel;
        }

        public static DeveloperApplicationViewModel MapDeveloperDataModelToDeveloperViewModel(DeveloperDataModel developerSubmissionDataModel)
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
