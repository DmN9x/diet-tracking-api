using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Diet.Tracking.API.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}