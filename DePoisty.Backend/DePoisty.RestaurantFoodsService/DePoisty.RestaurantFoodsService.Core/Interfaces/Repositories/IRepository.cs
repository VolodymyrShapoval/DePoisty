using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity);
        Task<OperationResult> DeleteAsync(T entity);
    }
}
