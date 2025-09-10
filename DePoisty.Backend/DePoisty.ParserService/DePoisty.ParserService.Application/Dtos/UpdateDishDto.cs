namespace DePoisty.ParserService.Application.Dtos
{
    public class UpdateDishDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
