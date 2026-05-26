using Diet.Tracking.API.Domain.Models;

namespace Diet.Tracking.API.Infrastructure.Abstractions.Repository
{
    public interface IUserRepository
    {
        public Task<UserModel> GetByIdAsync(int id);
    }
}

