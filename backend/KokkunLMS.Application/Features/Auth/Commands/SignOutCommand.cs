using MediatR;

namespace KokkunLMS.Application.Features.Auth.Commands;

public record SignOutCommand(int UserId) : IRequest<bool>; // Return true if revoked
