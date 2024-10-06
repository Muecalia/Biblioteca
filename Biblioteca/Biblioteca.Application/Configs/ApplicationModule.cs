using Biblioteca.Application.Commands.Request.Author;
using Biblioteca.Application.Handlers.Authors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.Configs
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers()
                .AddValidation();
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

        private static IServiceCollection AddValidation(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateAuthorRequest>();

            return services;
        }

    }
}
