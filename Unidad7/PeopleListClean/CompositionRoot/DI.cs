using Data.Repositories;
using Domain.UseCases;
using Domain.UseCases.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar repositorios concretos
            services.AddScoped<IPeopleRepository, PeopleRepository>();

            // Registrar casos de uso
            services.AddScoped<IPeopleListUseCase, PeopleListUseCase>();

            return services;
        }


    }
}
