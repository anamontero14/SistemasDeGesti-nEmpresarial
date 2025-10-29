using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonaRepository, Data.Repositories.PersonaRepository>();
            services.AddScoped<IPersonaRepositoryUseCase, Domain.UseCases.PersonaRepositoryUseCase>();

            return services;
        }
    }
}
