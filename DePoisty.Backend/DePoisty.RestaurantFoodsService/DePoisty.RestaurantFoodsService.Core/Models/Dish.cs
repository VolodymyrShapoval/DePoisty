namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Dish
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }

        public Restaurant Restaurant { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
