using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Queries;

public record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
