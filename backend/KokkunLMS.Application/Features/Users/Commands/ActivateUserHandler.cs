using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Commands;

public class ActivateUserHandler : IRequestHandler<ActivateUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<ActivateUserCommand> _validator;

    public ActivateUserHandler(IUnitOfWork uow, IValidator<ActivateUserCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<bool> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (user.IsDeleted)
            throw new ConflictException("Cannot activate a deleted user."); // Soft-deleted can't reactivate

        user.IsActive = true;
        return await _uow.Users.UpdateProfileAsync(user);
    }
}
