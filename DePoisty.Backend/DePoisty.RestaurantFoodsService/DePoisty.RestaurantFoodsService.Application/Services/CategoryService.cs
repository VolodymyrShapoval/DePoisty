using AutoMapper;
using DePoisty.RestaurantFoodsService.Application.DTOs.Categories;
using DePoisty.RestaurantFoodsService.Application.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategoryDTO?> GetByIdAsync(Guid id)
        {
            Category?  category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO?>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<OperationResult> AddAsync(CreateCategoryDTO createCategoryDTO)
        {
            Category category = _mapper.Map<Category>(createCategoryDTO);
            return await _repository.AddAsync(category);
        }

        public async Task<OperationResult> UpdateAsync(Guid id, UpdateCategoryDTO updateCategoryDTO)
        {
            Category? category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return OperationResult.Failure("Category hasn't been found");
            }
            _mapper.Map(updateCategoryDTO, category);
            return await _repository.UpdateAsync(category);
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            Category? category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return OperationResult.Failure("Category hasn't been found");
            }
            return await _repository.DeleteAsync(category);
        }
    }
}