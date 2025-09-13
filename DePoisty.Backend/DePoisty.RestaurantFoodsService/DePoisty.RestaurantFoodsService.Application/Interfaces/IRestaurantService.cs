using DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants;
using DePoisty.RestaurantFoodsService.Core.Common;

namespace DePoisty.RestaurantFoodsService.Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantDTO?> GetByIdAsync(Guid id);
        Task<RestaurantWithMetaDTO?> GetWithMetaByIdAsync(Guid id);
        Task<IEnumerable<RestaurantDTO>> GetAllAsync();
        Task<IEnumerable<RestaurantWithMetaDTO>> GetAllWithMetasAsync();
        Task<OperationResult> AddAsync(CreateRestaurantDTO createRestaurantDTO);
        Task<OperationResult> UpdateAsync(Guid id, UpdateRestaurantDTO updateRestaurantDTO);
        Task<OperationResult> DeleteAsync(Guid id);
    }
}
