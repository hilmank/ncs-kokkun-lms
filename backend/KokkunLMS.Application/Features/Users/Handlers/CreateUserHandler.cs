using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Commands;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Shared.Constants;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHasher _hasher;
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IFileStorageService _fileStorage;

    public CreateUserHandler(
        IUnitOfWork uow,
        IPasswordHasher hasher,
        IValidator<CreateUserCommand> validator,
        IFileStorageService fileStorage)
    {
        _uow = uow;
        _hasher = hasher;
        _validator = validator;
        _fileStorage = fileStorage;
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

        string profilePictureFileName = "default.png";

        if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
        {
            profilePictureFileName = await _fileStorage.SaveFileAsync(request.ProfilePicture, FileUploadFolders.ProfilePictures, cancellationToken);
        }

        var user = new User
        {
            Username = request.Username,
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            ProfilePicture = profilePictureFileName,
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
