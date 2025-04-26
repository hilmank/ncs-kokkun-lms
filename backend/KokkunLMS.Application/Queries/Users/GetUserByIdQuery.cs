using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public record GetUserByIdQuery(int UserId) : IRequest<UserDto>;
