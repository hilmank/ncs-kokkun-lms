using FluentValidation;
using KokkunLMS.Application.Features.Auth.Commands;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Features.Auth.Handlers;

public class SignInHandler : IRequestHandler<SignInCommand, SigninDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IJwtTokenService _jwt;
    private readonly IPasswordHasher _hasher;
    private readonly IValidator<SignInCommand> _validator;

    public SignInHandler(IUnitOfWork uow, IJwtTokenService jwt, IPasswordHasher hasher, IValidator<SignInCommand> validator)
    {
        _uow = uow;
        _jwt = jwt;
        _hasher = hasher;
        _validator = validator;
    }

    public async Task<SigninDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _uow.Users.GetByUsernameOrEmailAsync(request.UsernameOrEmail);
        if (user is null || !_hasher.Verify(user.PasswordHash, request.Password))
            throw new UnauthorizedAccessException("Invalid credentials.");
        var (accessToken, tokenExpirationMinutes) = _jwt.GenerateAccessToken(user);
        var newRefreshToken = _jwt.GenerateRefreshToken();

        SigninDto retVal = new()
        {
            Token = accessToken,
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryMinutes = tokenExpirationMinutes
        };
        // Generate new JWT
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(tokenExpirationMinutes);
        user.LastLogin = DateTime.UtcNow;
        _ = _uow.Users.UpdateProfileAsync(user);
        return retVal;
    }
}
