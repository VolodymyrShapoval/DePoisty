using DePoisty.ParserService.Application.Dtos;

namespace DePoisty.ParserService.Application.Interfaces
{
    public interface IParserOrchestrator
    {
        IEnumerable<AcceptParsingInfo> RunParsers(ParseRestaurantsRequest parseRestaurantsRequest, Func<UpdateRestaurantDto, Task> onComplete);
    }
}
