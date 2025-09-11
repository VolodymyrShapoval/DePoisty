namespace DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants
{
    public class UpdateRestaurantDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }
    }
}
