using DePoisty.ParserService.Infrastructure.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace DePoisty.ParserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHostedService<ParserBackgroundService>();

            return services;
        }
    }
}
