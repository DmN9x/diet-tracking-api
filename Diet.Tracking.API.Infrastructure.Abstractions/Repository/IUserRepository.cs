using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Responses;

namespace Diet.Tracking.API.Infrastructure.Abstractions.Repository
{
    public interface IUserRepository
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}

