using DePoisty.RestaurantFoodsService.Core.Enums;

namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class RestaurantMeta
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public ParsingType ParsingType { get; set; }
        public string ParsingClassName { get; set; } = string.Empty;

        public Restaurant Restaurant { get; set; } = null!;
    }
}
