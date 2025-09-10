namespace DePoisty.ParserService.Application.Dtos
{
    public class ParseRestaurantDto
    {
        public Guid Id { get; set; }
        public string Website { get; set; } = string.Empty;
        public RestaurantMetaDto RestaurantMeta { get; set; } = new ();
    }
}
