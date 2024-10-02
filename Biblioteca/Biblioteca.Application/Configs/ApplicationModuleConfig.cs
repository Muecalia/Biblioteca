using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.Configs
{
    public static class ApplicationModuleConfig
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Adicionar a insejeçã de independencia
            //services.AddScoped<IProjectService, ProjectService>();

            return services;
        }

    }
}
