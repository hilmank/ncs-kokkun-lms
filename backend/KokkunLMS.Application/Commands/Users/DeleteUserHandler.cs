using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<DeleteUserCommand> _validator;

    public DeleteUserHandler(IUnitOfWork uow, IValidator<DeleteUserCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (user.IsDeleted)
            throw new ConflictException("User is already deleted.");

        user.IsDeleted = true;
        user.IsActive = false; // Optionally deactivate too

        return await _uow.Users.UpdateProfileAsync(user);
    }
}
