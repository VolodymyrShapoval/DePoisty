namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface IRestaurantMetaService
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity);
        Task<OperationResult> DeleteAsync(T entity);
    }
}
