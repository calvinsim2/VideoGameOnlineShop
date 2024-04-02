using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IDeveloperService
    {
        Task<DeveloperDataModel> GetExplicitDeveloperAsync(Guid id);
        Task<IEnumerable<Developer>> GetAllExistingDevelopersAsync();
        Task AddDeveloperAsync(DeveloperDataModel developerSubmissionDataModel);
        Task UpdateSelectedDeveloperAsync(DeveloperDataModel developerDataModel);
        Task DeleteSelectedDeveloperAsync(Guid id);
    }
}
