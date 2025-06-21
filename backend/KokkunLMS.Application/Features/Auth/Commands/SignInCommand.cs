using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Features.Auth.Commands;

public record SignInCommand(string UsernameOrEmail, string Password) : IRequest<SigninDto>; // Return JWT Token
