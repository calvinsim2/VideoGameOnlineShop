namespace VideoGameOnlineShopDomain.Interfaces.CodesTable
{
    public interface ICodesTableRepository<T> where T : class, ICodesTableBase
    {
        Task<List<T>> FindAllCodesAsync();
        Task<T?> FindByCodeAsync(string code);
    }
}
