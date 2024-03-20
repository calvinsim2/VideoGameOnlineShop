using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IDeveloperService
    {
        Task<Developer?> GetExplicitDeveloperAsync(Guid id);
        Task<IEnumerable<Developer>> GetAllExistingDevelopersAsync();
    }
}
