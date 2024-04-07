using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.Common
{
    public class CodesTableExtension
    {
        public static void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder) where T : CodesTableBase
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
