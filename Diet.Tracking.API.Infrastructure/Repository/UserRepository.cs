using Dapper;
using Diet.Tracking.API.Domain.Models;
using Diet.Tracking.API.Infrastructure.Abstractions.Repository;
using Npgsql;

namespace Diet.Tracking.API.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _postgresConnection;
        private readonly string _basePath;
        public UserRepository (NpgsqlConnection postgresConnection)
        {
            _postgresConnection = postgresConnection;
            _basePath = "../Diet.Tracking.API.Infrastructure/Scripts/";
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var query = await File.ReadAllTextAsync(string.Concat(_basePath, "User/GetUserById.sql"));

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            await _postgresConnection.OpenAsync();
            var result = await _postgresConnection.QueryFirstOrDefaultAsync<UserModel>(query, parameters);
            await _postgresConnection.CloseAsync();

            return result;
        }
    }
}

