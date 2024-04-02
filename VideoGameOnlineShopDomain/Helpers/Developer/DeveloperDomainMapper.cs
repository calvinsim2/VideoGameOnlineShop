using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Helpers.Developer
{
    public class DeveloperDomainMapper
    {
        public static DomainModels.Developer MapDeveloperToDeveloperDataModel(DeveloperDataModel developerSubmissionDataModel)
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
        public static DeveloperDataModel MapDeveloperToDeveloperDataModel(DomainModels.Developer developer)
        {
            DeveloperDataModel developerSubmissionDataModel = new DeveloperDataModel
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
