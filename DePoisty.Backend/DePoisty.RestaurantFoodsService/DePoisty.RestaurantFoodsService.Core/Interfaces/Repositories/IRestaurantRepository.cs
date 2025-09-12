using DePoisty.RestaurantFoodsService.Core.Models;
using DePoisty.RestaurantFoodsService.Core.Specifications;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<Restaurant?> GetBySpecificationAndIdAsync(Guid id, ISpecification<Restaurant> specification);
        Task<IEnumerable<Restaurant>> GetBySpecificationAsync(ISpecification<Restaurant> specification);
    }
}
