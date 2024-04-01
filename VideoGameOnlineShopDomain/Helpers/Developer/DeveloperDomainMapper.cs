using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Helpers.Developer
{
    public class DeveloperDomainMapper
    {
        public static DomainModels.Developer MapDeveloperToDeveloperDataModel(DeveloperSubmissionDataModel developerSubmissionDataModel)
        {
            DomainModels.Developer developer = new DomainModels.Developer
            {
                Name = developerSubmissionDataModel.Name,
                Slogan = developerSubmissionDataModel.Slogan,
                Logo = developerSubmissionDataModel.Logo,
                DateTimeCreated = developerSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = developerSubmissionDataModel.DateTimeUpdated,
            };

            return developer;
        }
        public static DeveloperSubmissionDataModel MapDeveloperToDeveloperDataModel(DomainModels.Developer developer)
        {
            DeveloperSubmissionDataModel developerSubmissionDataModel = new DeveloperSubmissionDataModel
            {
                Name = developer.Name,
                Slogan = developer.Slogan,
                Logo = developer.Logo,
                DateTimeCreated = developer.DateTimeCreated,
                DateTimeUpdated = developer.DateTimeUpdated,
            };

            return developerSubmissionDataModel;
        }
    }
}
