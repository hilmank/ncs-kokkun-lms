using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public record AddChildToParentCommand(
    int ParentId,
    string StudentUsername,
    string StudentFullName,
    string StudentEmail,
    string StudentPhoneNumber
) : IRequest<int>; // returns studentId
