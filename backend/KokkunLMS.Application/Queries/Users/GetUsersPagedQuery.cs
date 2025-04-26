using KokkunLMS.Shared.DTOs;
using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public record GetUsersPagedQuery(
    int Page = 1,
    int PageSize = 10,
    string? SearchTerm = null,
    int? RoleId = null,
    bool? IsActive = null
) : IRequest<PagedResult<UserDto>>;
