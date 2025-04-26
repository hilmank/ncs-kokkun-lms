using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<UpdateUserCommand> _validator;

    public UpdateUserHandler(IUnitOfWork uow, IValidator<UpdateUserCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        // Only update if value is provided
        if (!string.IsNullOrWhiteSpace(request.FullName))
            user.FullName = request.FullName;

        if (!string.IsNullOrWhiteSpace(request.Email))
            user.Email = request.Email;

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            user.PhoneNumber = request.PhoneNumber;

        if (request.RoleId.HasValue)
            user.RoleId = request.RoleId.Value;

        return await _uow.Users.UpdateProfileAsync(user);
    }

}
