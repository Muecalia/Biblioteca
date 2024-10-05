using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure.Configs
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddServices();
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorBooksRepository, AuthorBooksRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanBooksRepository, LoanBooksRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

    }
}
