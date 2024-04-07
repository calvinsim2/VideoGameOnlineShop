using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.CodesTable
{
    public class CodeDecodeGenreConfiguration : IEntityTypeConfiguration<CodeDecodeGenre>
    {
        public void Configure(EntityTypeBuilder<CodeDecodeGenre> builder)
        {

            CodesTableExtension.ConfigureBaseEntity(builder);

        }
    }
}
