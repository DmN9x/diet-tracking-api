using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Exceptions;
using Diet.Tracking.API.Domain.Requests;
using Diet.Tracking.API.Domain.Responses;
using Diet.Tracking.API.Infrastructure.Abstractions.Repository;

namespace Diet.Tracking.API.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ValidationException(422, "User id must be informed!");
        
        var result = await _userRepository.GetByIdAsync(id);
        return result;
    }

    public async Task<UserResponse> CreateAsync(UserRequest userRequest)
    {
        var user = userRequest.CreateByRequest();
        user.Validate();
        
        var result = await _userRepository.CreateAsync(user);
        return result;
    }

    public async Task UpdateAsync(UserRequest user)
    {
        
    }

    public async Task DeleteAsync(int id)
    {
        
    }
}