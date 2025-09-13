namespace DePoisty.RestaurantFoodsService.Application.DTOs.Dishes
{
    public class DishDTO
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
    }
}
