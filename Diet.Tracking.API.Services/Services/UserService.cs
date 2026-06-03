using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Exceptions;
using Diet.Tracking.API.Domain.Requests;
using Diet.Tracking.API.Domain.Responses;
using Diet.Tracking.API.Infrastructure.Abstractions.Repository;
using Microsoft.Extensions.Logging;

namespace Diet.Tracking.API.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;
    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public async Task<UserResponse> GetByIdAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                _logger.LogError($"Id {id} informed is not valid.");
                throw new ValidationException(422, "User id must be informed!");
            }

            _logger.LogInformation($"Getting user with id {id}.");
            var result = await _userRepository.GetByIdAsync(id);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to fetch user with id {id}.", ex.Message);
            throw;
        }
    }

    public async Task CreateAsync(UserRequest userRequest)
    {
        try
        {
            var user = userRequest.CreateByRequest();
            user.Validate();

            _logger.LogInformation($"Creating user with id {user.Id}.");
            await _userRepository.CreateAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while creating user {userRequest.Email}.", ex.Message);
            throw;
        }
    }

    public async Task UpdateAsync(int id, UserRequest userRequest)
    {
        try
        {
            var user = userRequest.CreateByRequest(id);
            user.Validate();
            
            _logger.LogInformation($"Updating user with id {id}.");
            await _userRepository.UpdateAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update user with id {id}.", ex.Message);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation($"Deleting user with id {id}.");
            await _userRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete user {id}.", ex.Message);
            throw;
        }
    }
}