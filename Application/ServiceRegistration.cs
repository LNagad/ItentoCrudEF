using Core.Application.Interfaces.Services;
using Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IPokemonTypeService, PokemonTypeService>();
            services.AddTransient<IPokemonService, PokemonService>();

            return services;
        }
    }
}