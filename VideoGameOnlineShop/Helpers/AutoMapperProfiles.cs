using AutoMapper;
using VideoGameOnlineShopDomain.DomainModels.Common;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;

namespace VideoGameOnlineShopApplication.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CodesTableBase, CodeDecodeMatureRating>();

        }
    }
}
