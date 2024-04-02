using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface IDeveloperApplicationService
    {
        Task<DeveloperApplicationViewModel> GetExplicitDeveloperAsync(Guid id);
        Task AddDeveloperAsync(DeveloperSubmissionDto developerSubmissionDto);
        Task DeleteSelectedDeveloperAsync(Guid id);
    }
}
