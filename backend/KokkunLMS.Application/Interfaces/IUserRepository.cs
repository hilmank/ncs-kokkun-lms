using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail);
        Task<User?> GetByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> CreateAsync(User user);
        Task<bool> UpdateProfileAsync(User user);
    }
}
