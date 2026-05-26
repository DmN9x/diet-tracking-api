using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Exceptions;
using Diet.Tracking.API.Domain.Models;
using Diet.Tracking.API.Infrastructure.Abstractions.Repository;

namespace Diet.Tracking.API.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        return null;
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ValidationException(422, "User id must be informed!");
        
        var result = await _userRepository.GetByIdAsync(id);
        return result;
    }

    public async Task<int> CreateAsync(UserModel user)
    {
        return 0;
    }

    public async Task UpdateAsync(UserModel user)
    {
        
    }

    public async Task DeleteAsync(int id)
    {
        
    }
}