using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
