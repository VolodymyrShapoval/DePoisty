using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces.Repositories;
using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _context;
        public DishRepository(AppDbContext context) => _context = context;

        public async Task<RepositoryResult> AddAsync(Dish entity)
        {
            await _context.Dishes.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot add the entity to DB");
        }

        public async Task<RepositoryResult> DeleteAsync(Dish entity)
        {
            _context.Dishes.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot delete the entity from DB");
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<Dish?> GetByIdAsync(Guid id)
        {
            return await _context.Dishes.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<RepositoryResult> UpdateAsync(Dish entity)
        {
            var oldEntity = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == entity.Id);
            if (oldEntity == null)
            {
                return RepositoryResult.Failure("Cannot find the entity to update");
            }

            _context.Dishes.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot update the entity");
        }
    }
}
