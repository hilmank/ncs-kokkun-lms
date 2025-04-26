using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHasher _hasher;
    private readonly IValidator<CreateUserCommand> _validator;

    public CreateUserHandler(IUnitOfWork uow, IPasswordHasher hasher, IValidator<CreateUserCommand> validator)
    {
        _uow = uow;
        _hasher = hasher;
        _validator = validator;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var existingUser = await _uow.Users.GetByUsernameOrEmailAsync(request.Email);
        if (existingUser is not null)
            throw new ConflictException("Email is already registered.");

        var userByUsername = await _uow.Users.GetByUsernameOrEmailAsync(request.Username);
        if (userByUsername is not null)
            throw new ConflictException("Username is already taken.");

        var user = new User
        {
            Username = request.Username,
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            ProfilePicture = "default.png",
            PasswordHash = _hasher.Hash(request.Password),
            RoleId = request.RoleId,
            CreatedAt = DateTime.UtcNow,
            IsActive = false,
            IsDeleted = false
        };

        var userId = await _uow.Users.CreateAsync(user);
        return userId;
    }
}
