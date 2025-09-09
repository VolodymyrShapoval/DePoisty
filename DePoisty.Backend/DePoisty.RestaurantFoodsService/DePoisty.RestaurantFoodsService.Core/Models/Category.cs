namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
