using Diet.Tracking.API.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Diet.Tracking.API.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddExceptions(this IServiceCollection services)
    {
        services.AddScoped<ValidationException>();

        return services;
    }
}