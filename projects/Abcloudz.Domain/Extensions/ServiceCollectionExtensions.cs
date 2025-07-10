using Abcloudz.Domain.Repositories;
using Abcloudz.Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abcloudz.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
