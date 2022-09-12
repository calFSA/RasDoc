using Rasdoc.Entities.Models;
using RasDoc.API.Extensions;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using RasDoc.Domain.Notifications;
using RasDoc.Domain.Repository;
using RasDoc.Domain.Services;

namespace RasDoc.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<JwtAuth>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IReturnUserIdColaboradorService, ReturnUserIdColaboradorService>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoColaboradorRepository, ProjetoColaboradorRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<IClasseRepository, ClasseRepository>();
            services.AddScoped<IManutencaoDeClasseRepository, ManutencaoDeClasseRepository>();

            return services;
        }
    }
}
