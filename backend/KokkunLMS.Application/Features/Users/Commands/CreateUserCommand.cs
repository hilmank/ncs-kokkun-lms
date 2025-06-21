using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record CreateUserCommand(
    string Username,
    string FullName,
    string Email,
    string PhoneNumber,
    string Password,
    int RoleId
) : IRequest<int>;
