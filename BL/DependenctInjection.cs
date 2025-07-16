using AbcloudzWebAPI.BL.Services;
using System.Runtime.CompilerServices;

namespace AbcloudzWebAPI.BL;

public static class DependenctInjection
{
    public static IServiceCollection AddBL(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
