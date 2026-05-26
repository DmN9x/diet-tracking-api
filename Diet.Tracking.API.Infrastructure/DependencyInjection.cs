using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Diet.Tracking.API.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<NpgsqlConnection>(_ => 
            new NpgsqlConnection(configuration["POSTGRE_CONNECTION_STRING"]));

        return services;
    }
}