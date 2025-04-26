using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public record SignInCommand(string UsernameOrEmail, string Password) : IRequest<SigninDto>; // Return JWT Token
