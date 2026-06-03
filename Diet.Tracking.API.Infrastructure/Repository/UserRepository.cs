using Dapper;
using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Responses;
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

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var query = await File.ReadAllTextAsync(string.Concat(_basePath, "User/GetUserById.sql"));

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            await _postgresConnection.OpenAsync();
            var result = await _postgresConnection.QueryFirstOrDefaultAsync<UserResponse>(query, parameters);
            await _postgresConnection.CloseAsync();

            return result;
        }

        public async Task CreateAsync(User user)
        {
            var query = await File.ReadAllTextAsync(string.Concat(_basePath, "User/CreateUser.sql"));

            var parameters = new DynamicParameters();
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("BirthDate", user.BirthDate);
            parameters.Add("BiologicalGender", user.BiologicalGender);
            parameters.Add("CurrentWeight", user.CurrentWeight);
            parameters.Add("GoalWeight", user.GoalWeight);
            parameters.Add("Height", user.Height);
            parameters.Add("BMI", user.BMI);
            parameters.Add("WorkoutFrequency", user.WorkoutFrequency);
            parameters.Add("PersonalGoal", user.PersonalGoal);
            
            await _postgresConnection.OpenAsync();
            await _postgresConnection.ExecuteAsync(query, parameters);
            await _postgresConnection.CloseAsync();
        }
        
        public async Task UpdateAsync(User user)
        {
            var query = await File.ReadAllTextAsync(string.Concat(_basePath, "User/UpdateUser.sql"));

            var parameters = new DynamicParameters();
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("BirthDate", user.BirthDate);
            parameters.Add("BiologicalGender", user.BiologicalGender);
            parameters.Add("CurrentWeight", user.CurrentWeight);
            parameters.Add("GoalWeight", user.GoalWeight);
            parameters.Add("Height", user.Height);
            parameters.Add("BMI", user.BMI);
            parameters.Add("WorkoutFrequency", user.WorkoutFrequency);
            parameters.Add("PersonalGoal", user.PersonalGoal);
            parameters.Add("Id", user.Id);
            
            await _postgresConnection.OpenAsync();
            await _postgresConnection.QueryFirstOrDefaultAsync(query, parameters);
            await _postgresConnection.CloseAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var query = await File.ReadAllTextAsync(string.Concat(_basePath, "User/DeleteUserById.sql"));
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            
            await _postgresConnection.OpenAsync();
            await _postgresConnection.ExecuteAsync(query, parameters);
            await _postgresConnection.CloseAsync();
        }
    }
}

