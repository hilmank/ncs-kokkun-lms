using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record ChangePasswordCommand(
    int UserId,
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword
) : IRequest<bool>;
