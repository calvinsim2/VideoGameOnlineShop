using System.Net;
using VideoGameOnlineShopApplication.Helpers.CodesTable;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DomainModels.Common;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopDomain.Interfaces.CodesTable;

namespace VideoGameOnlineShopApplication.Services
{
    public class CodesTableApplicationService : ICodesTableApplicationService
    {
        private readonly ICodesTableRepository<CodeDecodeMatureRating> _codeDecodeMatureRatingRepository;

        public CodesTableApplicationService(ICodesTableRepository<CodeDecodeMatureRating> codeDecodeMatureRatingRepository)
        {
            _codeDecodeMatureRatingRepository = codeDecodeMatureRatingRepository;
        }

        public async Task<IEnumerable<CodesTableViewModel>> GetAllCodeMatureRatingAsync()
        {
            IEnumerable<CodeDecodeMatureRating> codeMatureRatings = await _codeDecodeMatureRatingRepository.FindAllCodesAsync();

            IEnumerable<CodesTableViewModel> codesTableViewModels = MapMultipleGameRecordToGameDataModel(codeMatureRatings);

            return codesTableViewModels;
        }

        public async Task<CodesTableViewModel> GetCodeMatureRatingByCodeAsync(string code)
        {
            CodeDecodeMatureRating codeMatureRating = await _codeDecodeMatureRatingRepository.FindByCodeAsync(code) ??
                                                      throw new HttpRequestException("Code not found", null, HttpStatusCode.NotFound);

            CodesTableViewModel codesTableViewModel = CodesTableApplicationMapper.MapCodesTableToCodesTableViewModel(codeMatureRating);

            return codesTableViewModel;
        }


        public IEnumerable<CodesTableViewModel> MapMultipleGameRecordToGameDataModel<T>(IEnumerable<T> codesTableRecords) where T : CodesTableBase
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
