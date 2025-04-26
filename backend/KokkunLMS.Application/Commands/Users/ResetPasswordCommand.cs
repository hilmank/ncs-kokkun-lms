using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record ResetPasswordCommand(
    int UserId,
    string NewPassword
) : IRequest<bool>;
