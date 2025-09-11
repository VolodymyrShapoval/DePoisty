using DePoisty.RestaurantFoodsService.Core.Enums;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas
{
    public class RestaurantMetaDTO
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public ParsingType ParsingType { get; set; }
        public string ParsingClassName { get; set; } = string.Empty;
    }
}
