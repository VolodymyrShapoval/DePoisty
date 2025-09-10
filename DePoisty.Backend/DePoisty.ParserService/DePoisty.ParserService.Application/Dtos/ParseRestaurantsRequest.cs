namespace DePoisty.ParserService.Application.Dtos
{
    public class ParseRestaurantsRequest
    {
        public List<ParseRestaurantDto> Restaurants { get; set; } = new List<ParseRestaurantDto>();
    }
}
