using DePoisty.ParserService.Application.Dtos;
using DePoisty.ParserService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DePoisty.ParserService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParsingController : ControllerBase
    {
        private readonly IParserOrchestrator _parserOrchestrator;

        public ParsingController(IParserOrchestrator parserOrchestrator)
        {
            _parserOrchestrator = parserOrchestrator;
        }

        [HttpPost("restaurants-foods")]
        public IActionResult ParseRestaurants([FromBody] ParseRestaurantsRequest parseRestaurantsRequest)
        {
            var listInfos = _parserOrchestrator.RunParsers(parseRestaurantsRequest, async updateRestaurantDto =>
                {
                    await Task.CompletedTask;
                    //TODO: sending request to save restaurants
                });
            return Ok(listInfos);
        }
    }
}
