using System.Threading.Tasks;

namespace VideoGameOnlineShopDomain.Interfaces.CodesTable
{
    public interface ICodesTableRepository<T> where T : class, ICodesTableBase
    {
        Task<List<T>> FindAllCodesAsync();
        Task<T?> FindByIdAsync(Guid id);
        Task<T?> FindByCodeAsync(string code);
        Task AddCodeAsync(T codesTable);
        void DeleteExplicitRecordAsync(T record);
        Task SaveChangesAsync();
    }
}
