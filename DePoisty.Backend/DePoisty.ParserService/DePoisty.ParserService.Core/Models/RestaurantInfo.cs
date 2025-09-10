namespace DePoisty.ParserService.Core.Models
{
    public class RestaurantInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }
    }
}
