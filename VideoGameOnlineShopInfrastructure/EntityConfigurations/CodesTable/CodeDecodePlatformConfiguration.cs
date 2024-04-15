using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.CodesTable
{
    public class CodeDecodePlatformConfiguration : IEntityTypeConfiguration<CodeDecodePlatform>
    {
        public void Configure(EntityTypeBuilder<CodeDecodePlatform> builder)
        {

            CodesTableExtension.ConfigureBaseEntity(builder);
        }
    }
}
