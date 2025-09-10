using DePoisty.ParserService.Application.Dtos;
using DePoisty.ParserService.Core.Interfaces;

namespace DePoisty.ParserService.Application.Interfaces
{
    public interface IParserOrchestrator
    {
        IRestaurantParser? GetRestaurantParserByClassName(string className);
        IEnumerable<AcceptParsingInfo> RunParsers(ParseRestaurantsRequest parseRestaurantsRequest, Func<UpdateRestaurantDto, Task> onComplete);
    }
}
