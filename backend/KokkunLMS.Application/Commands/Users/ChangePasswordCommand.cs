using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record ChangePasswordCommand(
    int UserId,
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword
) : IRequest<bool>;
