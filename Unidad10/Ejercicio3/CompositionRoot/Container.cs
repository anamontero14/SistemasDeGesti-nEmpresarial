using Domain.Interfaces.UseCase;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Repositories.RepositoriosPersona;
using Domain.UseCase;
using Data.Repositories.RepositoriosDepartamentos;
using Domain.UseCases;

namespace CompositionRoot
{
    public static class Container
    {
        //hay que instalar los paquetes nugget
        //addcomposition root 
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //registra esos repositorios con su clase
            services.AddScoped<IPersonaRepository, PersonasRepositoryAzure>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryAzure>();
            services.AddScoped<IPersonaRepositoryUseCase, PersonaRepositoryUseCase>();
            services.AddScoped<IDepartamentoRepositoryUseCase, DepartamentoRepositoryUseCase>();

            return services;
        }
    }
}
