using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.Dishes;
using DePoisty.RestaurantFoodsService.Application.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Services
{
    public class DishService : IDishService
    {
        private readonly IMapper _mapper;
        private readonly IDishRepository _repository;

        public DishService(IMapper mapper, IDishRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(CreateDishDTO createDishDTO)
        {
            Dish dish = _mapper.Map<Dish>(createDishDTO);
            return await _repository.AddAsync(dish);
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            Dish? dish = await _repository.GetByIdAsync(id);
            if (dish == null)
            {
                return OperationResult.Failure("Dish hasn't been found");
            }
            return await _repository.DeleteAsync(dish);
        }

        public async Task<IEnumerable<DishDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DishDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> UpdateAsync(Guid id, UpdateDishDTO updateDishDTO)
        {
            throw new NotImplementedException();
        }
    }
}
