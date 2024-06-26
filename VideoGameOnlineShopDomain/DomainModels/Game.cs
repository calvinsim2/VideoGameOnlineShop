﻿using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopDomain.DomainModels
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CodeMatureRating { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public virtual Guid DeveloperId { get; set; }
        public string CodeGenre { get; set; } = string.Empty;
        public string CodePlatform { get; set; } = string.Empty;
    }
}
