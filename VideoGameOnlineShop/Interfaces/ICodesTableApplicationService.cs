using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface ICodesTableApplicationService
    {
        #region CodeDecodeMatureRating
        Task<IEnumerable<CodesTableViewModel>> GetAllCodeMatureRatingAsync();
        Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeMatureRatingByCodesAsync(string codes);
        Task<CodesTableViewModel> GetCodeMatureRatingByCodeAsync(string code);
        Task AddCodeMatureRatingAsync(CodesTableDto codesTableDto);
        Task DeleteExplicitCodeMatureRatingAsync(Guid id);

        #endregion

        #region CodeDecodeMatureGenre
        Task<IEnumerable<CodesTableViewModel>> GetAllCodeGenreAsync();
        Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeGenreByCodesAsync(string codes);
        Task<CodesTableViewModel> GetCodeGenreByCodeAsync(string code);
        Task AddCodeGenreAsync(CodesTableDto codesTableDto);
        Task DeleteExplicitCodeGenreAsync(Guid id);

        #endregion

        #region CodeDecodePlatform

        Task<IEnumerable<CodesTableViewModel>> GetAllCodePlatformAsync();
        Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeDecodePlatformByCodesAsync(string codes);
        Task<CodesTableViewModel> GetCodePlatformByCodeAsync(string code);
        Task AddCodePlatformAsync(CodesTableDto codesTableDto);
        Task DeleteExplicitCodePlatformAsync(Guid id);

        #endregion
    }
}
