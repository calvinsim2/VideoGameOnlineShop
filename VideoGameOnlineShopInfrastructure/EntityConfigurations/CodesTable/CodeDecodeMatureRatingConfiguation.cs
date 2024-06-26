﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopInfrastructure.EntityConfigurations.Common;

namespace VideoGameOnlineShopInfrastructure.EntityConfigurations.CodesTable
{
    public class CodeDecodeMatureRatingConfiguation : IEntityTypeConfiguration<CodeDecodeMatureRating>
    {
        public void Configure(EntityTypeBuilder<CodeDecodeMatureRating> builder)
        {

            CodesTableExtension.ConfigureBaseEntity(builder);
        }
    }
}
