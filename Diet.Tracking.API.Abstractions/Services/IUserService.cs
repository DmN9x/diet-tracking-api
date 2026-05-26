using Diet.Tracking.API.Domain.Models;

namespace Diet.Tracking.API.Abstractions.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserModel>> GetAllAsync();
        public Task<UserModel> GetByIdAsync(int id);
        public Task<int> CreateAsync(UserModel user);
        public Task UpdateAsync(UserModel user);
        public Task DeleteAsync(int id);
    }
}
