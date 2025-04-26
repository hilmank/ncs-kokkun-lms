using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using MediatR;

namespace KokkunLMS.Application.Commands.Users;

public class AddChildToParentHandler : IRequestHandler<AddChildToParentCommand, int>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<AddChildToParentCommand> _validator;

    public AddChildToParentHandler(
        IUnitOfWork uow,
        IValidator<AddChildToParentCommand> validator)
    {
        _uow = uow;
        _validator = validator;
    }

    public async Task<int> Handle(AddChildToParentCommand request, CancellationToken cancellationToken)
    {
        // Validate input
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        // Ensure parent exists and is a parent role
        var parent = await _uow.Users.GetByIdAsync(request.ParentId);
        if (parent == null || parent.RoleId != 6)
            throw new NotFoundException("Parent not found.");

        // Ensure unique student
        if (await _uow.Users.GetByUsernameOrEmailAsync(request.StudentEmail) is not null)
            throw new ConflictException("Student email is already registered.");
        if (await _uow.Users.GetByUsernameOrEmailAsync(request.StudentUsername) is not null)
            throw new ConflictException("Student username is already taken.");

        // Prepare student entity
        var student = new Domain.Entities.User
        {
            Username = request.StudentUsername,
            FullName = request.StudentFullName,
            Email = request.StudentEmail,
            PhoneNumber = request.StudentPhoneNumber,
            PasswordHash = parent.PasswordHash, // Use parent's password hash for simplicity
            RoleId = 5,
            ProfilePicture = "default.png",
            CreatedAt = DateTime.UtcNow,
            IsActive = false,
            IsDeleted = false
        };

        // Use repository method that handles student creation and linking (with transaction)
        return await _uow.Users.AddChildForParentAsync(request.ParentId, student);
    }
}
