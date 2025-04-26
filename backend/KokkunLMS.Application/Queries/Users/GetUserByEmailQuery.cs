using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public record GetUserByEmailQuery(string Email) : IRequest<UserDto>;
