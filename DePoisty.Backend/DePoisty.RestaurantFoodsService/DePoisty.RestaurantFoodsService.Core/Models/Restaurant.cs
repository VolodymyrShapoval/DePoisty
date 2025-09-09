namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        public RestaurantMeta RestaurantMeta { get; set; } = null!;
    }
}
