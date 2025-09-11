using System.Linq.Expressions;

namespace DePoisty.RestaurantFoodsService.Core.Specifications
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, bool>>? Criteria { get; }
    }
}
