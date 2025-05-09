using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<UpdateUserProfileCommand> _validator;

    public UpdateUserProfileHandler(IUnitOfWork uow, IValidator<UpdateUserProfileCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var user = await _uow.Users.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (!string.IsNullOrWhiteSpace(request.FullName))
            user.FullName = request.FullName;

        if (!string.IsNullOrWhiteSpace(request.Email))
            user.Email = request.Email;

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            user.FullName = request.PhoneNumber;

        return await _uow.Users.UpdateProfileAsync(user);
    }
}
