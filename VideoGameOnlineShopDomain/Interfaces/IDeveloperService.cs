using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IDeveloperService
    {
        Task<DeveloperDataModel> GetExplicitDeveloperAsync(Guid id);
        Task<IEnumerable<DeveloperDataModel>> GetAllExistingDevelopersAsync();
        Task AddDeveloperAsync(DeveloperDataModel developerSubmissionDataModel);
        Task UpdateSelectedDeveloperAsync(DeveloperDataModel developerDataModel);
        Task DeleteSelectedDeveloperAsync(Guid id);
    }
}
