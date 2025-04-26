using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record RegisterUserCommand(
    string ParentUsername,
    string ParentFullName,
    string ParentEmail,
    string ParentPhoneNumber,
    string ParentPassword,
    string ParentConfirmPassword,

    string StudentUsername,
    string StudentFullName,
    string StudentEmail,
    string StudentPhoneNumber
) : IRequest<int>; // Return parentId
