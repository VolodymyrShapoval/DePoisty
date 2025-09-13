namespace DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants
{
    public class RestaurantDTO
    {
        public Guid Id { get; set; }
        public Guid RestaurantMetaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }
    }
}
