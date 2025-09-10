using DePoisty.ParserService.Application.Dtos;
using DePoisty.ParserService.Core.Interfaces;

namespace DePoisty.ParserService.Application.Interfaces
{
    public interface IParserOrchestrator
    {
        IEnumerable<AcceptParsingInfo> RunParsers(ParseRestaurantsRequest parseRestaurantsRequest, Func<UpdateRestaurantDto, Task> onComplete);
    }
}
