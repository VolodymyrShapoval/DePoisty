using DePoisty.ParserService.Application.Dtos;
using DePoisty.ParserService.Application.Interfaces;
using DePoisty.ParserService.Core.Interfaces;

namespace DePoisty.ParserService.Application.Services
{
    public class ParserOrchestrator : IParserOrchestrator
    {
        private readonly IEnumerable<IRestaurantParser> _parsers;
        public ParserOrchestrator(IEnumerable<IRestaurantParser> parsers)
        {
            _parsers = parsers;
        }
        public IRestaurantParser? GetRestaurantParserByClassName(string className)
        {
            var parser = _parsers.FirstOrDefault(p => p.GetType().Name == className);

            return parser;
        }
        public IEnumerable<AcceptParsingInfo> RunParsers(ParseRestaurantsRequest parseRestaurantsRequest, Action<UpdateRestaurantDto> onComplete)
        {
            var listInfos = new List<AcceptParsingInfo>();
            foreach (var restaurant in parseRestaurantsRequest.Restaurants)
            {
                var parser = GetRestaurantParserByClassName(restaurant.RestaurantMeta.ParsingClassName);
                if (parser == null)
                {
                    listInfos.Add(new AcceptParsingInfo
                    {
                        ParsingClassName = restaurant.RestaurantMeta.ParsingClassName,
                        IsAccepted = false
                    });
                }
                else
                {
                    listInfos.Add(new AcceptParsingInfo
                    {
                        ParsingClassName = restaurant.RestaurantMeta.ParsingClassName,
                        IsAccepted = true
                    });
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            var restaurantInfo = await parser.ParseRestaurantInfoAsync(restaurant.Website);
                            var dishesInfos = await parser.ParseDishInfosAsync(restaurant.Website);

                            var updateRestaurant = new UpdateRestaurantDto
                            {
                                Id = restaurant.Id,
                                Website = restaurant.Website,
                                Name = restaurantInfo.Name,
                                Address = restaurantInfo.Address,
                                QualityRating = restaurantInfo.QualityRating,
                                Dishes = dishesInfos.Select(dish => new UpdateDishDto
                                {
                                    CategoryName = dish.CategoryName,
                                    Name = dish.Name,
                                    Price = dish.Price,
                                    Weight = dish.Weight
                                })
                                .ToList()
                            };
                            onComplete.Invoke(updateRestaurant); //TODO: review the logic
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"Exception in background parser task for '{restaurant.RestaurantMeta.ParsingClassName}': {ex}");
                        }
                    });
                }
            }

            return listInfos;
        }
    }
}
