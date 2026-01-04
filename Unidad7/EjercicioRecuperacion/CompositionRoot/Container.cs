using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    /// <summary>
    /// Clase que centraliza la configuración de Inyección de Dependencias
    /// siguiendo el patrón Composition Root
    /// </summary>
    public static class Container
    {
        /// <summary>
        /// Método de extensión que registra todas las dependencias del sistema
        /// </summary>
        /// <param name="services">Colección de servicios de ASP.NET</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <returns>La colección de servicios con las dependencias registradas</returns>
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar Repositorios (Capa de Datos)
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            // Registrar Casos de Uso (Capa de Dominio)
            services.AddScoped<IUseCasePersona, UseCasePersona>();
            services.AddScoped<IUseCaseJuego, UseCaseJuego>();

            return services;
        }
    }
}