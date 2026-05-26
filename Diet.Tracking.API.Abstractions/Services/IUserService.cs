using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Requests;
using Diet.Tracking.API.Domain.Responses;

namespace Diet.Tracking.API.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> CreateAsync(UserRequest userRequest);
        Task UpdateAsync(UserRequest userRequest);
        Task DeleteAsync(int id);
    }
}
