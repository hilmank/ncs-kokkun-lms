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

        Task<int> RegisterParentWithStudentAsync(User parent, User student);
        Task<int> AddChildForParentAsync(int parentId, User student);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
    }
}
