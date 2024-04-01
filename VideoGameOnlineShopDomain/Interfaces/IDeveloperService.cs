using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IDeveloperService
    {
        Task<DeveloperSubmissionDataModel> GetExplicitDeveloperAsync(Guid id);
        Task<IEnumerable<Developer>> GetAllExistingDevelopersAsync();
        Task AddDeveloperAsync(DeveloperSubmissionDataModel developerSubmissionDataModel);
    }
}
