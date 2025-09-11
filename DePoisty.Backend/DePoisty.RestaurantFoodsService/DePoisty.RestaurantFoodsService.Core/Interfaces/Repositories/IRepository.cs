using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Models;
using DePoisty.RestaurantFoodsService.Core.Specifications;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<RepositoryResult> AddAsync(T entity);
        Task<RepositoryResult> UpdateAsync(T entity);
        Task<RepositoryResult> DeleteAsync(T entity);
    }
}
