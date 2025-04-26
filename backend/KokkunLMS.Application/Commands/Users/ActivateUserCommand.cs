using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record ActivateUserCommand(
    int UserId
) : IRequest<bool>;
