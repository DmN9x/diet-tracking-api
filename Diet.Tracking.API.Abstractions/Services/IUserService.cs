using Diet.Tracking.API.Domain.Entities;
using Diet.Tracking.API.Domain.Requests;
using Diet.Tracking.API.Domain.Responses;

namespace Diet.Tracking.API.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task CreateAsync(UserRequest userRequest);
        Task UpdateAsync(int id, UserRequest userRequest);
        Task DeleteAsync(int id);
    }
}
