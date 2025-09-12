using DePoisty.RestaurantFoodsService.Application.DTOs.Categories;
using DePoisty.RestaurantFoodsService.Core.Common;
namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<OperationResult> AddAsync(CreateCategoryDTO createCategoryDTO);
        Task<OperationResult> UpdateAsync(Guid id, UpdateCategoryDTO updateCategoryDTO);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
