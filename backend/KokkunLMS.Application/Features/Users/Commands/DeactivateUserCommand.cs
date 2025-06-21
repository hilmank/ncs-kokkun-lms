using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record DeactivateUserCommand(
    int UserId
) : IRequest<bool>;
