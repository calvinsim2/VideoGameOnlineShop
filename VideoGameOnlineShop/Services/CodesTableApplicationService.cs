using AutoMapper;
using System.Net;
using VideoGameOnlineShopApplication.Helpers.CodesTable;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopApplication.Models.ViewModels;
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

        public CodesTableApplicationService(IMapper mapper, 
                                            ICodesTableRepository<CodeDecodeMatureRating> codeDecodeMatureRatingRepository,
                                            ICodesTableRepository<CodeDecodeGenre> codeDecodeGenreRepository)
        {
            _mapper = mapper;
            _codeDecodeMatureRatingRepository = codeDecodeMatureRatingRepository;
            _codeDecodeGenreRepository = codeDecodeGenreRepository;
        }

        #region CodeDecodeMatureRating
        public async Task<IEnumerable<CodesTableViewModel>> GetAllCodeMatureRatingAsync()
        {
            IEnumerable<CodeDecodeMatureRating> codeMatureRatings = await _codeDecodeMatureRatingRepository.FindAllCodesAsync();

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleCodesTableRecordToCodesTableViewModel(codeMatureRatings);

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
