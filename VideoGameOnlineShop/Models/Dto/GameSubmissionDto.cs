namespace VideoGameOnlineShopApplication.Models.Dto
{
    public class GameSubmissionDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CodeMatureRating { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string DeveloperId { get; set; }
        public string CodeGenre { get; set; } = string.Empty;
    }
}
