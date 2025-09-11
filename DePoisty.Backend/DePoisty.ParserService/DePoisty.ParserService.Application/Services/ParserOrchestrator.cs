using DePoisty.ParserService.Application.Dtos;
using DePoisty.ParserService.Application.Interfaces;
using DePoisty.ParserService.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DePoisty.ParserService.Application.Services
{
    public class ParserOrchestrator : IParserOrchestrator
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IServiceProvider _serviceProvider;

        public ParserOrchestrator(
            IBackgroundTaskQueue taskQueue,
            IServiceProvider serviceProvider)
        {
            _taskQueue = taskQueue;
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<AcceptParsingInfo> RunParsers(
            ParseRestaurantsRequest parseRestaurantsRequest,
            Func<UpdateRestaurantDto, Task> onComplete)
        {
            var listInfos = new List<AcceptParsingInfo>();

            var availableParsers = _serviceProvider.GetServices<IRestaurantParser>();
            var parserTypeNames = availableParsers.Select(p => p.GetType().Name).ToHashSet();

            foreach (var restaurant in parseRestaurantsRequest.Restaurants)
            {
                var className = restaurant.RestaurantMeta.ParsingClassName;

                var parserExists = parserTypeNames.Contains(className);

                listInfos.Add(new AcceptParsingInfo
                {
                    ParsingClassName = className,
                    IsAccepted = parserExists
                });

                if (parserExists)
                {
                    _taskQueue.Queue(async (token, sp) =>
                    {
                        var parsers = sp.GetServices<IRestaurantParser>();
                        var parser = parsers.FirstOrDefault(p => p.GetType().Name == className);

                        if (parser == null) return;

                        var restaurantInfoTask = parser.ParseRestaurantInfoAsync(restaurant.Website);
                        var dishesInfosTask = parser.ParseDishInfosAsync(restaurant.Website);

                        var restaurantInfo = await restaurantInfoTask;
                        var dishesInfos = await dishesInfosTask;

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
                            }).ToList()
                        };

                        await onComplete.Invoke(updateRestaurant);
                    });
                }
            }

            return listInfos;
        }
    }
}
