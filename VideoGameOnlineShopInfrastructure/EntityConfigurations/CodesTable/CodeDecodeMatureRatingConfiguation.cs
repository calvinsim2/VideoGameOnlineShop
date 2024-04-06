using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.CodesTable
{
    public class CodeDecodeMatureRatingConfiguation : IEntityTypeConfiguration<CodeDecodeMatureRating>
    {
        public void Configure(EntityTypeBuilder<CodeDecodeMatureRating> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(true)
                .HasColumnType("UniqueIdentifier")
                .HasDefaultValueSql("newsequentialId()");

            builder.Property(e => e.Code)
                .IsRequired(true)
                .HasColumnType("nvarchar(20)");

            builder.Property(e => e.DecodeValue)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");
        }
    }
}
