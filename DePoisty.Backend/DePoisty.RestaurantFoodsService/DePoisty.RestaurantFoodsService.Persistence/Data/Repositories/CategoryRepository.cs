using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<OperationResult> AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? OperationResult.Success() : OperationResult.Failure("Cannot add the entity to DB");
        }

        public async Task<OperationResult> DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? OperationResult.Success() : OperationResult.Failure("Cannot delete the entity from DB");
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<OperationResult> UpdateAsync(Category entity)
        {
            var oldEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (oldEntity == null)
            {
                return OperationResult.Failure("Cannot find the entity to update");
            }
            _context.Categories.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? OperationResult.Success() : OperationResult.Failure("Cannot update the entity");
        }
    }
}
