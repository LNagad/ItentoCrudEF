using Core.Application.Interfaces.Repositories;
using Infrastructure.persistence.Contexts;
using Infrastructure.persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPokemonRepository, PokemonRepository>();

            return services;
        }
    }
}