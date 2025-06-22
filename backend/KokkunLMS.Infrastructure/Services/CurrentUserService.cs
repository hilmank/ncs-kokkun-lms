using System.Security.Claims;
using KokkunLMS.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace KokkunLMS.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int? UserId { get; }
        public int? RoleId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int userId))
                UserId = userId;

            var roleIdClaim = user?.FindFirst("role_id")?.Value;
            if (int.TryParse(roleIdClaim, out int roleId))
                RoleId = roleId;
        }
    }
}
