using DePoisty.RestaurantFoodsService.Core.Common;
using DePoisty.RestaurantFoodsService.Core.Interfaces;
using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Repositories
{
    class RestaurantMetaRepository : IRepository<RestaurantMeta>
    {
        private readonly AppDbContext _context;
        public RestaurantMetaRepository(AppDbContext context) => _context = context;

        public async Task<RepositoryResult> AddAsync(RestaurantMeta entity)
        {
            await _context.RestaurantMetas.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return (result > 0) ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot add the entity to DB");
        }

        public async Task<RepositoryResult> DeleteAsync(RestaurantMeta entity)
        {
            _context.RestaurantMetas.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot delete the entity from DB");
        }

        public async Task<IEnumerable<RestaurantMeta>> GetAllAsync()
        {
            return await _context.RestaurantMetas.ToListAsync();
        }

        public async Task<RestaurantMeta?> GetByIdAsync(Guid id)
        {
            return await _context.RestaurantMetas.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RepositoryResult> UpdateAsync(RestaurantMeta entity)
        {
            var oldEntity = await _context.RestaurantMetas.FirstOrDefaultAsync(r => r.Id == entity.Id);
            if (oldEntity == null)
            {
                return RepositoryResult.Failure("Cannot find the entity to update");
            }

            _context.RestaurantMetas.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? RepositoryResult.Success() : RepositoryResult.Failure("Cannot update the entity");
        }
    }
}
