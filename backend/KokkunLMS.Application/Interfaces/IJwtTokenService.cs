using System.Security.Claims;
using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    (string token, double tokenExpirationMinutes) GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
