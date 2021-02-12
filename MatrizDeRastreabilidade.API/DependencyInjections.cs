using MatrizDeRastreabilidade.API.Models;
using MatrizDeRastreabilidade.API.Repositories;
using MatrizDeRastreabilidade.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MatrizDeRastreabilidade.API
{
    public class DependencyInjections
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }
    }
}
