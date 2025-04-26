using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record DeactivateUserCommand(
    int UserId
) : IRequest<bool>;
