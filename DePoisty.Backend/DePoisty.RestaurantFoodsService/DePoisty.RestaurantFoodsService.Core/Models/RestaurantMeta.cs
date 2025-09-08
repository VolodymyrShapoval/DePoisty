using DePoisty.RestaurantFoodsService.Core.Enums;

namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class RestaurantMeta
    {
        public required Guid Id { get; set; }
        public required Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
        public required ParsingType ParsingType { get; set; }
        public required string ParsingClassName { get; set; }
    }
}
