using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record ActivateUserCommand(
    int UserId
) : IRequest<bool>;
