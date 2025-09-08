namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Category
    {
        public required string Id { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
