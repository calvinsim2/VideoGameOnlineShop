﻿namespace VideoGameOnlineShopDomain.DataModels
{
    public class GameSubmissionDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool MatureRating { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid DeveloperId { get; set; }
        public string CodeGenre { get; set; } = string.Empty;
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
    }
}
