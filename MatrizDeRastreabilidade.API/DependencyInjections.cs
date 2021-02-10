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
        }
    }
}
