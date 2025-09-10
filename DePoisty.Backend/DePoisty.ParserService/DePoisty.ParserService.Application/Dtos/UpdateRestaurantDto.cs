namespace DePoisty.ParserService.Application.Dtos
{
    public class UpdateRestaurantDto
    {
        public Guid Id { get; set; }
        public string Website { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal QualityRating { get; set; }
        public List<UpdateDishDto> Dishes { get; set; } = [];
    }
}
