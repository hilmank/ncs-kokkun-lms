using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record ChangePasswordCommand(
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword
) : IRequest<bool>;
