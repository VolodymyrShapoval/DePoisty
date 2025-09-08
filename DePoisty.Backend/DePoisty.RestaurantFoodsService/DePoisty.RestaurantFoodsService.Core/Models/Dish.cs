namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Dish
    {
        public required Guid Id { get; set; }
        public required Guid CategoryId { get; set; }
        public required Category Category { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
