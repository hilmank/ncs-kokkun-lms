using System.Data;
using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHasher _hasher;
    private readonly IValidator<RegisterUserCommand> _validator;

    public RegisterUserHandler(
        IUnitOfWork uow,
        IPasswordHasher hasher,
        IValidator<RegisterUserCommand> validator)
    {
        _uow = uow;
        _hasher = hasher;
        _validator = validator;
    }

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // 🧪 Validate input
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        // Check for duplicates before proceeding
        async Task EnsureUniqueAsync(string value)
        {
            if (await _uow.Users.GetByUsernameOrEmailAsync(value) is not null)
                throw new ConflictException($"{value} is already used.");
        }

        await EnsureUniqueAsync(request.ParentUsername);
        await EnsureUniqueAsync(request.ParentEmail);
        await EnsureUniqueAsync(request.StudentUsername);
        await EnsureUniqueAsync(request.StudentEmail);

        // Create parent user
        var parent = new User
        {
            Username = request.ParentUsername,
            FullName = request.ParentFullName,
            Email = request.ParentEmail,
            PhoneNumber = request.ParentPhoneNumber,
            PasswordHash = _hasher.Hash(request.ParentPassword),
            RoleId = 6,
            ProfilePicture = "default.png",
            CreatedAt = DateTime.UtcNow,
            IsActive = false,
            IsDeleted = false
        };

        // Create student user
        var student = new Domain.Entities.User
        {
            Username = request.StudentUsername,
            FullName = request.StudentFullName,
            Email = request.StudentEmail,
            PhoneNumber = request.StudentPhoneNumber,
            PasswordHash = _hasher.Hash(request.ParentPassword),
            RoleId = 5,
            ProfilePicture = "default.png",
            CreatedAt = DateTime.UtcNow,
            IsActive = false,
            IsDeleted = false
        };

        // Delegate to repository method that handles transaction
        return await _uow.Users.RegisterParentWithStudentAsync(parent, student);
    }
}
