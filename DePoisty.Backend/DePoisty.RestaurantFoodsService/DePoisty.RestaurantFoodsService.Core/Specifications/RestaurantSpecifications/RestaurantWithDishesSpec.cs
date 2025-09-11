using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Core.Specifications.RestaurantSpecifications
{
    public class RestaurantWithDishesSpec : BaseSpecification<Restaurant>
    {
        public RestaurantWithDishesSpec()
        {
            AddInclude(r => r.Dishes);
        }
    }
}
