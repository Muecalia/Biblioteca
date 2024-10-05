using Biblioteca.Application.Handlers.Authors;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.Configs
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Adicionar a insejeçã de independencia
            //services.AddScoped<IProjectService, ProjectService>();
            //services.AddMediatR()
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateAuthorHandler>());

            return services;
        }

    }
}
