using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations
{
    public class DeveloperEntityConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            Extensions.ConfigureBaseEntity(builder);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Slogan)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Logo)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
        }
    }
}
