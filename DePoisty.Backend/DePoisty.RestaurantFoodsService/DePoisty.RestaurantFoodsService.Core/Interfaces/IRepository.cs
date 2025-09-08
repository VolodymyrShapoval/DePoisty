using DePoisty.RestaurantFoodsService.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePoisty.RestaurantFoodsService.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync<T>(Guid id);
        Task<IEnumerable<T>> GetAllAsync<T>();
        Task<RepositoryResult> AddAsync<T>(T entity);
        Task<RepositoryResult> UpdateAsync<T>(T entity);
        Task<RepositoryResult> DeleteAsync<T>(T entity);
    }
}
