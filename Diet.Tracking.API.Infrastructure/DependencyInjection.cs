using Diet.Tracking.API.Infrastructure.Abstractions.Repository;
using Diet.Tracking.API.Infrastructure.Handler;
using Diet.Tracking.API.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Diet.Tracking.API.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        Dapper.SqlMapper.AddTypeHandler(new DateTimeTypeHandler());
        
        services.AddScoped<NpgsqlConnection>(_ => 
            new NpgsqlConnection(configuration["POSTGRE_CONNECTION_STRING"]));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}