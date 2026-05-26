using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Models;

namespace Diet.Tracking.API.Services;

public class UserService : IUserService
{
    public UserService()
    {
        
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        return null;
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        return null;
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