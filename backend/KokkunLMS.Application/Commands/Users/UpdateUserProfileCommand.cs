using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record UpdateUserProfileCommand(
    int UserId,
    string? FullName,
    string? Email,
    string? PhoneNumber
) : IRequest<bool>;
