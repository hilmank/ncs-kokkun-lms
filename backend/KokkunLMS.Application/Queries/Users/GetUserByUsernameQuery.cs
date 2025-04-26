using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
