using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface ICRUDService<T1, T2, T3, T4>
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity);
        Task<OperationResult> DeleteAsync(T entity);
    }
}
