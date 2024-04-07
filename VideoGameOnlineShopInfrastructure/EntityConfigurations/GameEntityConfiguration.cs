using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            Extensions.ConfigureBaseEntity(builder);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Description)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.CodeMatureRating)
                .IsRequired(true)
                .HasColumnType("nvarchar(1)");

            builder.Property(e => e.Rating)
                .IsRequired(true)
                .HasColumnType("decimal(13,2)");

            builder.Property(e => e.Price)
                .IsRequired(true)
                .HasColumnType("decimal(13,2)");

            builder.Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.DeveloperId)
                .IsRequired(true)
                .HasColumnType("UniqueIdentifier");

            builder.Property(e => e.CodeGenre)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");
        }
    }
}
