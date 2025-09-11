using DePoisty.RestaurantFoodsService.Application.DTOs.Categories;
using DePoisty.RestaurantFoodsService.Core.Common;
namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<OperationResult> AddAsync(CreateCategoryDTO entity);
        Task<OperationResult> UpdateAsync(Guid id, UpdateCategoryDTO entity);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
