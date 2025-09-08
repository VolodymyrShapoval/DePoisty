namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Restaurant
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
        public required float QualityRating { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
