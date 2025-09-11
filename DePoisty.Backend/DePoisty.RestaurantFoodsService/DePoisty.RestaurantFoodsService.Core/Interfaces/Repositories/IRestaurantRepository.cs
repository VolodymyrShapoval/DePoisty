using DePoisty.RestaurantFoodsService.Core.Models;
using DePoisty.RestaurantFoodsService.Core.Specifications;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetBySpecificationAsync(ISpecification<Restaurant> specification);
    }
}
