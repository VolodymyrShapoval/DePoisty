using DePoisty.RestaurantFoodsService.Core.Models;

namespace DePoisty.RestaurantFoodsService.Core.Specifications.RestaurantSpecifications
{
    public class RestaurantWithMetaSpec : BaseSpecification<Restaurant>
    {
        public RestaurantWithMetaSpec()
        {
            AddInclude(r => r.RestaurantMeta);
        }
    }
}
