using DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas;
using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface IRestaurantMetaService
    {
        Task<RestaurantMetaDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<RestaurantMetaDTO>> GetAllAsync();
        Task<OperationResult> AddAsync(CreateRestaurantMetaDTO entity);
        Task<OperationResult> UpdateAsync(Guid id, UpdateRestaurantMetaDTO entity);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
