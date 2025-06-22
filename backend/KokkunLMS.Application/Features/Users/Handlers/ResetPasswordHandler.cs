using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Commands;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Handlers;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<ResetPasswordCommand> _validator;
    private readonly IPasswordHasher _hasher;
    private readonly ICurrentUserService _currentUser;

    public ResetPasswordHandler(
        IUnitOfWork uow,
        IValidator<ResetPasswordCommand> validator,
        IPasswordHasher hasher,
        ICurrentUserService currentUser)
    {
        _uow = uow;
        _validator = validator;
        _hasher = hasher;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        user.PasswordHash = _hasher.Hash(request.NewPassword);
        user.LastPasswordChange = DateTime.UtcNow;
        user.UpdatedAt = user.LastPasswordChange;
        user.UpdatedBy = _currentUser.UserId;
        return await _uow.Users.UpdateProfileAsync(user);
    }
}
