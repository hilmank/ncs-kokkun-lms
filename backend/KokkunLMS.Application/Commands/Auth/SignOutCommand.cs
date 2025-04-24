using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public record SignOutCommand(int UserId) : IRequest<bool>; // Return true if revoked
