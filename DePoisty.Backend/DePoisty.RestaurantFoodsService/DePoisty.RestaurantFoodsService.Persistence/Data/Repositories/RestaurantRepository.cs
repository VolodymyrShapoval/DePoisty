using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly AppDbContext _context;
        public RestaurantRepository(AppDbContext context) => _context = context;

        public async Task<RepositoryResult> AddAsync(Restaurant entity)
        {
            await _context.Restaurants.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return (result > 0) ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot add the entity to DB");
        }

        public async Task<RepositoryResult> DeleteAsync(Restaurant entity)
        {
            _context.Restaurants.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot delete the entity to DB");
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(Guid id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RepositoryResult> UpdateAsync(Restaurant entity)
        {
            var oldEntity = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == entity.Id);
            if (oldEntity == null)
            {
                return RepositoryResult.Failure("Cannot find the entity to update");
            }

            _context.Restaurants.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot update the entity to DB");
        }
    }
}
