using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record UpdateUserProfileCommand(
    int UserId,
    string? FullName,
    string? Email,
    string? PhoneNumber
) : IRequest<bool>;
