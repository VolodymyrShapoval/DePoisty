using DePoisty.RestaurantFoodsService.Core.Enums;

namespace DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas
{
    public class UpdateRestaurantMetaDTO
    {
        public ParsingType ParsingType { get; set; }
        public string ParsingClassName { get; set; } = string.Empty;
    }
}
