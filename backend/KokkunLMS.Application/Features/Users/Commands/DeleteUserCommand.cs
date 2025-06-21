using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record DeleteUserCommand(
    int UserId
) : IRequest<bool>;
