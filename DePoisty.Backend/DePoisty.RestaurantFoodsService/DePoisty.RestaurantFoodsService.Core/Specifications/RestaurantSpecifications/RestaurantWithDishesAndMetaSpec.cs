using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Core.Specifications.RestaurantSpecifications
{
    public class RestaurantWithDishesAndMetaSpec : BaseSpecification<Restaurant>
    {
        public RestaurantWithDishesAndMetaSpec()
        {
            AddInclude(r => r.Dishes);
            AddInclude(r => r.RestaurantMeta);
        }
    }
}
