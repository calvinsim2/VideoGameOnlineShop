using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            Extensions.ConfigureBaseEntity(builder);

            builder.Property(e => e.DisplayName)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasColumnType("varbinary(MAX)");

            builder.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasColumnType("varbinary(MAX)");

            builder.Property(e => e.IsAdmin)
                .IsRequired()
                .HasColumnType("bit");

        }
    }
}
