using DePoisty.RestaurantFoodsService.Core.Enums;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas
{
    public class CreateRestaurantMetaDTO
    {
        public ParsingType ParsingType { get; set; }
        public string ParsingClassName { get; set; } = string.Empty;
    }
}
