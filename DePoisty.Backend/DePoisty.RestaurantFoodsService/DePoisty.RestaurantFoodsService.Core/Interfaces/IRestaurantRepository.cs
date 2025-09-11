using DePoisty.RestaurantFoodsService.Core.Models;
using DePoisty.RestaurantFoodsService.Core.Specifications;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<List<Restaurant>> GetBySpecificationAsync(ISpecification<Restaurant> specification);
    }
}
