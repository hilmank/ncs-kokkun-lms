using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public record AddChildToParentCommand(
    int ParentId,
    string StudentUsername,
    string StudentFullName,
    string StudentEmail,
    string StudentPhoneNumber
) : IRequest<int>; // returns studentId
