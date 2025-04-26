using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record DeleteUserCommand(
    int UserId
) : IRequest<bool>;
