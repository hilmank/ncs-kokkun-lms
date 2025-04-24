using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public record SignInCommand(string UsernameOrEmail, string Password) : IRequest<string>; // Return JWT Token
