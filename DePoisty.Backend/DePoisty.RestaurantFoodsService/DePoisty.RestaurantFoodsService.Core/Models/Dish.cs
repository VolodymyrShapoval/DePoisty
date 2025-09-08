using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePoisty.RestaurantFoodsService.Core.Models
{
    public class Dish
    {
        public required string Id { get; set; }
        public required Category CategoryId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Weight { get; set; }
        public required string Description { get; set; }
        public decimal PricePerHundredGrams { get; set; }
    }
}
