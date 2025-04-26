using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<DeactivateUserCommand> _validator;

    public DeactivateUserHandler(IUnitOfWork uow, IValidator<DeactivateUserCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<bool> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (user.IsDeleted)
            throw new ConflictException("Cannot deactivate a deleted user.");

        user.IsActive = false;
        return await _uow.Users.UpdateProfileAsync(user);
    }
}
