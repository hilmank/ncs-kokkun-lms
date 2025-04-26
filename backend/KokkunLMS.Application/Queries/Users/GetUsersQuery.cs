using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public record GetUsersQuery(
    bool? IsActive = null,
    bool? IsDeleted = null,
    int? RoleId = null
) : IRequest<IEnumerable<UserDto>>;
