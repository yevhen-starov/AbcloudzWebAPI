using AbcloudzWebAPI.Mapping;
using AbcloudzWebAPI.Services;
using AbcloudzWebAPI.Services.Interfaces;

namespace AbcloudzWebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddAbcloudzMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<AbcloudzMappingProfile>();
            });

            return services;
        }
    }
}
