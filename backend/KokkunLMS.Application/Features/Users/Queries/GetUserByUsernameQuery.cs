using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Queries;

public record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
