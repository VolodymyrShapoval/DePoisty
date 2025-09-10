using DePoisty.ParserService.Application.Interfaces;
using DePoisty.ParserService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DePoisty.ParserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IParserOrchestrator, ParserOrchestrator>();

            return services;
        }
    }
}
