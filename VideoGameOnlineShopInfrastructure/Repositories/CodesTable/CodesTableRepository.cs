using Microsoft.EntityFrameworkCore;
using VideoGameOnlineShopDomain.DomainModels.Common;
using VideoGameOnlineShopDomain.Interfaces.CodesTable;
using VideoGameOnlineShopInfrastructure.Repositories.Common;

namespace VideoGameOnlineShopInfrastructure.Repositories.CodesTable
{
    public class CodesTableRepository<T> : ICodesTableRepository<T> where T : class, ICodesTableBase
    {
        protected readonly VideoGameOnlineShopDbContext _context;

        public CodesTableRepository(VideoGameOnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> FindAllCodesAsync()
        {
            var classRecordList = await _context.Set<T>().ToListAsync();
            return classRecordList;
        }

        public async Task<T?> FindByCodeAsync(string code)
        {
            var codeRecord = await _context.Set<T>().Where(c => c.Code == code).FirstOrDefaultAsync();
            return codeRecord;
        }
    }

}
