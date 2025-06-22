using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Queries;

public record GetUserByIdQuery(int UserId) : IRequest<UserDto>;
