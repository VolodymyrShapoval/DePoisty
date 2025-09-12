using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.Restaurants;
using DePoisty.RestaurantFoodsService.Application.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;
using DePoisty.RestaurantFoodsService.Core.Specifications.RestaurantSpecifications;

namespace DePoisty.RestaurantFoodsService.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IMapper mapper, IRestaurantRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(CreateRestaurantDTO createRestaurantDTO)
        {
            Restaurant restaurant = _mapper.Map<Restaurant>(createRestaurantDTO);
            return await _repository.AddAsync(restaurant);
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return OperationResult.Failure("Restaurant hasn't been found");
            }
            return await _repository.DeleteAsync(restaurant);
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllAsync()
        {
            IEnumerable<Restaurant> restaurants = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
        }

        public async Task<IEnumerable<RestaurantWithMetaDTO>> GetAllWithMetasAsync()
        {
            IEnumerable<Restaurant> restaurants = await _repository.GetBySpecificationAsync(new RestaurantWithMetaSpec());
            return _mapper.Map<IEnumerable<RestaurantWithMetaDTO>>(restaurants);
        }

        public async Task<RestaurantDTO?> GetByIdAsync(Guid id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            return _mapper.Map<RestaurantDTO?>(restaurant);
        }

        public async Task<RestaurantWithMetaDTO?> GetWithMetaByIdAsync(Guid id)
        {
            Restaurant? restaurant = await _repository.GetBySpecificationAndIdAsync(id, new RestaurantWithMetaSpec());
            return _mapper.Map<RestaurantWithMetaDTO?>(restaurant);
        }

        public async Task<OperationResult> UpdateAsync(Guid id, UpdateRestaurantDTO updateRestaurantDTO)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if(restaurant == null)
            {
                return OperationResult.Failure("Restaurant hasn't been found");
            }

            _mapper.Map(updateRestaurantDTO, restaurant);
            return await _repository.UpdateAsync(restaurant);
        }
    }
}
