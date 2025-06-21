using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Queries;

public record GetUsersQuery(
    bool? IsActive = null,
    bool? IsDeleted = null,
    int? RoleId = null
) : IRequest<IEnumerable<UserDto>>;
