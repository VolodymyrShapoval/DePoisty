namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Dish
    {
        public required string Id { get; set; }
        public required Category CategoryId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal PricePerHundredGrams { get; set; }
    }
}
