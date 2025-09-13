using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.RestaurantMetas;
using DePoisty.RestaurantFoodsService.Application.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Services
{
    public class RestaurantMetaService : IRestaurantMetaService
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantMetaRepository _repository;

        public RestaurantMetaService(IMapper mapper, IRestaurantMetaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(CreateRestaurantMetaDTO createRestaurantMetaDTO)
        {
            RestaurantMeta restaurantMeta = _mapper.Map<RestaurantMeta>(createRestaurantMetaDTO);
            return await _repository.AddAsync(restaurantMeta);
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            RestaurantMeta? restaurantMeta = await _repository.GetByIdAsync(id);
            if (restaurantMeta == null)
            {
                return OperationResult.Failure("RestaurantMeta hasn't been found");
            }
            return await _repository.DeleteAsync(restaurantMeta);
        }

        public async Task<IEnumerable<RestaurantMetaDTO>> GetAllAsync()
        {
            IEnumerable<RestaurantMeta> restaurantMetas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RestaurantMetaDTO>>(restaurantMetas);
        }

        public async Task<RestaurantMetaDTO?> GetByIdAsync(Guid id)
        {
            RestaurantMeta? restaurantMeta = await _repository.GetByIdAsync(id);
            return _mapper.Map<RestaurantMetaDTO?>(restaurantMeta);
        }

        public async Task<OperationResult> UpdateAsync(Guid id, UpdateRestaurantMetaDTO updateRestaurantMetaDTO)
        {
            RestaurantMeta? restaurantMeta = await _repository.GetByIdAsync(id);
            if(restaurantMeta == null)
            {
                return OperationResult.Failure("RestaurantMeta hasn't been found");
            }

            _mapper.Map(updateRestaurantMetaDTO, restaurantMeta);
            return await _repository.UpdateAsync(restaurantMeta);
        }
    }
}
