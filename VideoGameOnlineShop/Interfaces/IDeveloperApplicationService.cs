using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface IDeveloperApplicationService
    {
        Task<IEnumerable<DeveloperApplicationViewModel>> GetAllDevelopersAsync();
        Task<DeveloperApplicationViewModel> GetExplicitDeveloperAsync(Guid id);
        Task AddDeveloperAsync(DeveloperSubmissionDto developerSubmissionDto);
        Task UpdateSelectedDeveloperAsync(DeveloperUpdateDto developerUpdateDto);
        Task DeleteSelectedDeveloperAsync(Guid id);
    }
}
