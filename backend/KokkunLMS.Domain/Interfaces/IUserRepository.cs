using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> CreateAsync(User user);
        Task<bool> UpdateProfileAsync(User user);
    }
}
