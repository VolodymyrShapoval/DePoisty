using DePoisty.ParserService.Core.Interfaces;
using DePoisty.ParserService.Core.Models;
using DePoisty.ParserService.Infrastructure.Selenium;

namespace DePoisty.ParserService.Infrastructure.Services.Parsers
{
    public abstract class BaseParser : IRestaurantParser, IDisposable
    {
        private readonly SeleniumWrapper _seleniumWrapper;
        public string Url { get; set; } = string.Empty;
        public BaseParser()
        {
            _seleniumWrapper = new SeleniumWrapper(headless: true);
        }

        public void Dispose()
        {
            _seleniumWrapper.Dispose();
        }

        public async Task<IEnumerable<DishInfo>> ParseDishInfosAsync(string url)
        {
            if (!string.IsNullOrEmpty(Url) && Url != url) throw new ArgumentException("Different url of restaurant website");
            Url = url;
            return await ParseRestaurantDishesAsync();
        }

        public async Task<RestaurantInfo> ParseRestaurantInfoAsync(string url)
        {
            if (!string.IsNullOrEmpty(Url) && Url != url) throw new ArgumentException("Different url of restaurant website");
            Url = url;
            return new RestaurantInfo
            {
                Name = await ParseRestaurantNameAsync(),
                Address = await ParseRestaurantAddressAsync(),
                QualityRating = await ParseRestaurantQualityRatingAsync()
            };
        }
        public abstract Task<string> ParseRestaurantNameAsync();
        public abstract Task<string> ParseRestaurantAddressAsync();
        public abstract Task<decimal> ParseRestaurantQualityRatingAsync();
        public abstract Task<IEnumerable<DishInfo>> ParseRestaurantDishesAsync();
    }
}
