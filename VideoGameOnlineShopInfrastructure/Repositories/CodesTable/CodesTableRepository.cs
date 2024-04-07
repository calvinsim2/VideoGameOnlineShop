using Microsoft.EntityFrameworkCore;
using VideoGameOnlineShopDomain.Interfaces.CodesTable;

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

        public async Task<T?> FindByIdAsync(Guid id)
        {
            var codeRecord = await _context.Set<T>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return codeRecord;
        }

        public async Task<T?> FindByCodeAsync(string code)
        {
            var codeRecord = await _context.Set<T>().Where(c => c.Code == code).FirstOrDefaultAsync();
            return codeRecord;
        }

        public async Task AddCodeAsync(T codesTable)
        {
            await _context.Set<T>().AddAsync(codesTable);
        }

        public void DeleteExplicitRecordAsync(T record)
        {
            _context.Set<T>().Remove(record);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
