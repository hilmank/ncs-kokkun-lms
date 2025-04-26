using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record UpdateUserCommand(
    int UserId,
    string? FullName,
    string? Email,
    string? PhoneNumber,
    int? RoleId
) : IRequest<bool>;
