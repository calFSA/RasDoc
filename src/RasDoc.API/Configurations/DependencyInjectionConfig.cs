using RasDoc.API.Extensions;
using RasDoc.Domain.Interfaces;
using RasDoc.Domain.Notifications;

namespace RasDoc.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<JwtAuth>();

            return services;
        }
    }
}
