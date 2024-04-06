using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopApplication.Helpers.CodesTable
{
    public class CodesTableApplicationMapper
    {
        public static CodesTableBase MapCodesTableDtoToCodesTableBase(CodesTableDto codesTableDto)
        {
            CodesTableBase newCodesTableBase = new CodesTableBase
            {
                Code = codesTableDto.Code,
                DecodeValue = codesTableDto.DecodeValue
            };

            return newCodesTableBase;

        }

        public static CodesTableViewModel MapCodesTableToCodesTableViewModel(CodesTableBase codesTableBase)
        {
            CodesTableViewModel codesTableViewModel = new CodesTableViewModel
            {
                Id = codesTableBase.Id,
                Code = codesTableBase.Code,
                DecodeValue = codesTableBase.DecodeValue
            };

            return codesTableViewModel;
        }
    }
}
