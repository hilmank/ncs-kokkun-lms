using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record ResetPasswordCommand(
    int UserId,
    string NewPassword
) : IRequest<bool>;
