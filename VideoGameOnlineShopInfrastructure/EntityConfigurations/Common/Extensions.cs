using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.Common
{
    public static class Extensions
    {
        public static void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(true)
                .HasColumnType("UniqueIdentifier")
                .HasDefaultValueSql("newsequentialId()");

            builder.Property(e => e.DateTimeCreated).HasColumnType("datetimeoffset");

            builder.Property(e => e.DateTimeUpdated).HasColumnType("datetimeoffset");
        }
    }
}
