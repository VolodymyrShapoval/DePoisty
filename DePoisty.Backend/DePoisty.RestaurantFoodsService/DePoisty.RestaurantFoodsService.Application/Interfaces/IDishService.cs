using DePoisty.RestaurantFoodsService.Application.DTOs.Dishes;
using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface IDishService
    {
        Task<DishDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<DishDTO>> GetAllAsync();
        Task<OperationResult> AddAsync(CreateDishDTO entity);
        Task<OperationResult> UpdateAsync(Guid id, UpdateDishDTO entity);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
