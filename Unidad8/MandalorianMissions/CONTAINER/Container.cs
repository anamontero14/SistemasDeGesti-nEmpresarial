using DATA;
using DOMAIN.INTERFACES;
using DOMAIN.USECASES;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTAINER
{
    public static class Container
    {
        //hay que instalar los paquetes nugget
        //addcomposition root 
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //registra esos repositorios con su clase
            services.AddScoped<IRepositoryMisiones, RepositoryMisiones>();
            services.AddScoped<IUseCaseListadoMisiones, ListadoMisionesUseCase>();

            return services;
        }
    }
}
