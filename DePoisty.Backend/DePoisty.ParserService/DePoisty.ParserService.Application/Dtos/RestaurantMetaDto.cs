using DePoisty.ParserService.Core.Enums;

namespace DePoisty.ParserService.Application.Dtos
{
    public class RestaurantMetaDto
    {
        public ParsingType ParsingType { get; set; }
        public string ParsingClassName { get; set; } = string.Empty;
    }
}
