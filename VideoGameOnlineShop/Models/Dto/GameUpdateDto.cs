﻿namespace VideoGameOnlineShopApplication.Models.Dto
{
    public class GameUpdateDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CodeMatureRating { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string DeveloperId { get; set; } = string.Empty;
        public string CodeGenre { get; set; } = string.Empty;
        public string CodePlatform { get; set; } = string.Empty;
    }
}
