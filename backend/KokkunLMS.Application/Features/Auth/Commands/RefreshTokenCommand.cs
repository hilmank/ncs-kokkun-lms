using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Features.Auth.Commands;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<SigninDto>;
