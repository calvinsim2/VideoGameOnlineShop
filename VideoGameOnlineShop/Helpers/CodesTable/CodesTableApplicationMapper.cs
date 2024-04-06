using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopApplication.Helpers.CodesTable
{
    public class CodesTableApplicationMapper
    {
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
