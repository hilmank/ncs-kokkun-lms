using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<ChangePasswordCommand> _validator;
    private readonly IPasswordHasher _hasher;

    public ChangePasswordHandler(IUnitOfWork uow, IValidator<ChangePasswordCommand> validator, IPasswordHasher hasher)
    {
        _uow = uow;
        _validator = validator;
        _hasher = hasher;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (!_hasher.Verify(user.PasswordHash, request.CurrentPassword))
            throw new UnauthorizedAccessException("Current password is incorrect.");

        user.PasswordHash = _hasher.Hash(request.NewPassword);
        user.LastPasswordChange = DateTime.UtcNow;
        return await _uow.Users.UpdateProfileAsync(user); // assumes it updates the whole user object
    }
}
