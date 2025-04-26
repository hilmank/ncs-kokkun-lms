using System.Security.Claims;
using FluentValidation;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, SigninDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IJwtTokenService _jwt;
    private readonly IValidator<RefreshTokenCommand> _validator;

    public RefreshTokenHandler(IUnitOfWork uow, IJwtTokenService jwt, IValidator<RefreshTokenCommand> validator)
    {
        _uow = uow;
        _jwt = jwt;
        _validator = validator;
    }

    public async Task<SigninDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _uow.Users.GetByRefreshTokenAsync(request.RefreshToken);

        if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Invalid or expired refresh token.");

        // Validate access token
        var principal = _jwt.GetPrincipalFromExpiredToken(request.Token);
        if (principal == null || !principal.Identity.IsAuthenticated)
            throw new UnauthorizedAccessException("Invalid access token");

        // Ensure token belongs to the same user
        var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        if (user.UserId != userId)
            throw new UnauthorizedAccessException("User ID mismatch");

        // Generate new Access & Refresh Tokens
        var (accessToken, tokenExpirationMinutes) = _jwt.GenerateAccessToken(user);
        var newRefreshToken = _jwt.GenerateRefreshToken();

        // Update refresh token in database
        SigninDto retVal = new()
        {
            Token = accessToken,
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryMinutes = tokenExpirationMinutes
        };
        // Generate new JWT
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(tokenExpirationMinutes);
        _ = _uow.Users.UpdateProfileAsync(user);
        return retVal;
    }
}
