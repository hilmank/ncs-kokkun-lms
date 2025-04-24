using FluentValidation;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public class SignInHandler : IRequestHandler<SignInCommand, string>
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

    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _uow.Users.GetByUsernameOrEmailAsync(request.UsernameOrEmail);
        if (user is null || !_hasher.Verify(user.PasswordHash, request.Password))
            throw new UnauthorizedAccessException("Invalid credentials.");

        return _jwt.GenerateToken(user);
    }
}
