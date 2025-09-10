using DePoisty.ParserService.Core.Models;

namespace DePoisty.ParserService.Core.Interfaces
{
    public interface IRestaurantParser
    {
        Task<RestaurantInfo> ParseRestaurantInfoAsync(string url);
        Task<IEnumerable<DishInfo>> ParseDishInfosAsync(string url);
    }
}
