using AutoMapper;
using System.Net;
using VideoGameOnlineShopApplication.Helpers.CodesTable;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.Common;
using VideoGameOnlineShopDomain.DomainModels.Common;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopDomain.Interfaces.CodesTable;

namespace VideoGameOnlineShopApplication.Services
{
    public class CodesTableApplicationService : ICodesTableApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ICodesTableRepository<CodeDecodeMatureRating> _codeDecodeMatureRatingRepository;
        private readonly ICodesTableRepository<CodeDecodeGenre> _codeDecodeGenreRepository;
        private readonly ICodesTableRepository<CodeDecodePlatform> _codeDecodePlatformRepository;

        public CodesTableApplicationService(IMapper mapper, 
                                            ICodesTableRepository<CodeDecodeMatureRating> codeDecodeMatureRatingRepository,
                                            ICodesTableRepository<CodeDecodeGenre> codeDecodeGenreRepository,
                                            ICodesTableRepository<CodeDecodePlatform> codeDecodePlatformRepository)
        {
            _mapper = mapper;
            _codeDecodeMatureRatingRepository = codeDecodeMatureRatingRepository;
            _codeDecodeGenreRepository = codeDecodeGenreRepository;
            _codeDecodePlatformRepository = codeDecodePlatformRepository;
        }

        #region CodeDecodeMatureRating
        public async Task<IEnumerable<CodesTableViewModel>> GetAllCodeMatureRatingAsync()
        {
            IEnumerable<CodeDecodeMatureRating> codeMatureRatings = await _codeDecodeMatureRatingRepository.FindAllCodesAsync();

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(codeMatureRatings);

            return codesTableViewModels;
        }

        public async Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeMatureRatingByCodesAsync(string codes)
        {
            List<string> codesList = CommonUtilityMethods.ConvertStringsToListRemoveNullAndEmptyElements(codes).ToList();

            IEnumerable<CodeDecodeMatureRating> codeMatureRatings = await _codeDecodeMatureRatingRepository.FindAllCodesAsync();

            IEnumerable<CodeDecodeMatureRating> filteredCodeMatureRatings = codeMatureRatings.Where(cmr => codesList.Contains(cmr.Code));

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(filteredCodeMatureRatings);

            return codesTableViewModels;
        }

        public async Task<CodesTableViewModel> GetCodeMatureRatingByCodeAsync(string code)
        {
            CodeDecodeMatureRating codeMatureRating = await _codeDecodeMatureRatingRepository.FindByCodeAsync(code) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            CodesTableViewModel codesTableViewModel = CodesTableApplicationMapper.MapCodesTableToCodesTableViewModel(codeMatureRating);

            return codesTableViewModel;
        }

        public async Task AddCodeMatureRatingAsync(CodesTableDto codesTableDto)
        {
            CodesTableBase codesTableBase = CodesTableApplicationMapper.MapCodesTableDtoToCodesTableBase(codesTableDto);
            CodeDecodeMatureRating codeDecodeMatureRating = _mapper.Map<CodeDecodeMatureRating>(codesTableBase);
            await _codeDecodeMatureRatingRepository.AddCodeAsync(codeDecodeMatureRating);
            await _codeDecodeMatureRatingRepository.SaveChangesAsync();

        }

        public async Task DeleteExplicitCodeMatureRatingAsync(Guid id)
        {
            CodeDecodeMatureRating codeMatureRating = await _codeDecodeMatureRatingRepository.FindByIdAsync(id) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            _codeDecodeMatureRatingRepository.DeleteExplicitRecordAsync(codeMatureRating);
            await _codeDecodeMatureRatingRepository.SaveChangesAsync();

        }

        #endregion

        #region CodeDecodeGenre

        public async Task<IEnumerable<CodesTableViewModel>> GetAllCodeGenreAsync()
        {
            IEnumerable<CodeDecodeGenre> codeMatureRatings = await _codeDecodeGenreRepository.FindAllCodesAsync();

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(codeMatureRatings);

            return codesTableViewModels;
        }

        public async Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeGenreByCodesAsync(string codes)
        {
            List<string> codesList = CommonUtilityMethods.ConvertStringsToListRemoveNullAndEmptyElements(codes).ToList();

            IEnumerable<CodeDecodeGenre> codeGenres = await _codeDecodeGenreRepository.FindAllCodesAsync();

            IEnumerable<CodeDecodeGenre> filteredCodeGenres = codeGenres.Where( cg => codesList.Contains(cg.Code));

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(filteredCodeGenres);

            return codesTableViewModels;
        }

        public async Task<CodesTableViewModel> GetCodeGenreByCodeAsync(string code)
        {

            CodeDecodeGenre codeGenre = await _codeDecodeGenreRepository.FindByCodeAsync(code) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            CodesTableViewModel codesTableViewModel = CodesTableApplicationMapper.MapCodesTableToCodesTableViewModel(codeGenre);

            return codesTableViewModel;
        }

        public async Task AddCodeGenreAsync(CodesTableDto codesTableDto)
        {
            CodesTableBase codesTableBase = CodesTableApplicationMapper.MapCodesTableDtoToCodesTableBase(codesTableDto);
            CodeDecodeGenre codeDecodeGenre = _mapper.Map<CodeDecodeGenre>(codesTableBase);
            await _codeDecodeGenreRepository.AddCodeAsync(codeDecodeGenre);
            await _codeDecodeGenreRepository.SaveChangesAsync();

        }

        public async Task DeleteExplicitCodeGenreAsync(Guid id)
        {
            CodeDecodeGenre codeGenre = await _codeDecodeGenreRepository.FindByIdAsync(id) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            _codeDecodeGenreRepository.DeleteExplicitRecordAsync(codeGenre);
            await _codeDecodeGenreRepository.SaveChangesAsync();

        }

        #endregion

        #region CodeDecodePlatform

        public async Task<IEnumerable<CodesTableViewModel>> GetAllCodePlatformAsync()
        {
            IEnumerable<CodeDecodePlatform> codePlatforms = await _codeDecodePlatformRepository.FindAllCodesAsync();

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(codePlatforms);

            return codesTableViewModels;
        }

        public async Task<IEnumerable<CodesTableViewModel>> GetSelectedCodeDecodePlatformByCodesAsync(string codes)
        {
            List<string> codesList = CommonUtilityMethods.ConvertStringsToListRemoveNullAndEmptyElements(codes).ToList();

            IEnumerable<CodeDecodePlatform> codePlatforms = await _codeDecodePlatformRepository.FindAllCodesAsync();

            IEnumerable<CodeDecodePlatform> filteredCodePlatforms = codePlatforms.Where(cg => codesList.Contains(cg.Code));

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(filteredCodePlatforms);

            return codesTableViewModels;
        }

        public async Task<CodesTableViewModel> GetCodePlatformByCodeAsync(string code)
        {

            CodeDecodePlatform codePlatform = await _codeDecodePlatformRepository.FindByCodeAsync(code) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            CodesTableViewModel codesTableViewModel = CodesTableApplicationMapper.MapCodesTableToCodesTableViewModel(codePlatform);

            return codesTableViewModel;
        }

        public async Task AddCodePlatformAsync(CodesTableDto codesTableDto)
        {
            CodesTableBase codesTableBase = CodesTableApplicationMapper.MapCodesTableDtoToCodesTableBase(codesTableDto);
            CodeDecodePlatform codeDecodePlatform = _mapper.Map<CodeDecodePlatform>(codesTableBase);
            await _codeDecodePlatformRepository.AddCodeAsync(codeDecodePlatform);
            await _codeDecodePlatformRepository.SaveChangesAsync();

        }

        public async Task DeleteExplicitCodePlatformAsync(Guid id)
        {
            CodeDecodePlatform codeDecodePlatform = await _codeDecodePlatformRepository.FindByIdAsync(id) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            _codeDecodePlatformRepository.DeleteExplicitRecordAsync(codeDecodePlatform);
            await _codeDecodePlatformRepository.SaveChangesAsync();

        }

        #endregion

        public IEnumerable<CodesTableViewModel> MapMultipleCodesTableRecordToCodesTableViewModel<T>(IEnumerable<T> codesTableRecords) where T : CodesTableBase
        {
            if (codesTableRecords is null || !codesTableRecords.Any())
            {
                return new List<CodesTableViewModel>();
            }

            List<CodesTableViewModel> newCodesTableViewModels = new List<CodesTableViewModel>();

            foreach (var codesTableRecord in codesTableRecords)
            {
                newCodesTableViewModels.Add(CodesTableApplicationMapper.MapCodesTableToCodesTableViewModel(codesTableRecord));
            }

            return newCodesTableViewModels;

        }
    }
}
