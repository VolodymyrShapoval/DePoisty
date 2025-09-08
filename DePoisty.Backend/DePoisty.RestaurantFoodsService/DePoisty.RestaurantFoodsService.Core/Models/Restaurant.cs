namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Restaurant
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
        public required decimal QualityRating { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

        public RestaurantMeta RestaurantMeta { get; set; } = null!;
    }
}
