using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces
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
