using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Responses;

namespace Diet.Tracking.API.Infrastructure.Abstractions.Repository
{
    public interface IUserRepository
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> CreateAsync(User user);
    }
}

