using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<SigninDto>;
