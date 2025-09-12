using DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas;
using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface IRestaurantMetaService
    {
        Task<RestaurantMetaDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<RestaurantMetaDTO>> GetAllAsync();
        Task<OperationResult> AddAsync(CreateRestaurantMetaDTO createRestaurantMetaDTO);
        Task<OperationResult> UpdateAsync(Guid id, UpdateRestaurantMetaDTO updateRestaurantMetaDTO);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
