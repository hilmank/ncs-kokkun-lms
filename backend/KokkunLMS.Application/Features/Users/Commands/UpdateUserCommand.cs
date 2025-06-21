using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record UpdateUserCommand(
    int UserId,
    string? FullName,
    string? Email,
    string? PhoneNumber,
    int? RoleId
) : IRequest<bool>;
