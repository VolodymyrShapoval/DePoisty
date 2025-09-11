using DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants
{
    public class CreateRestaurantDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }
        public RestaurantMetaDTO RestaurantMetaDTO { get; set; } = null!;
    }
}
