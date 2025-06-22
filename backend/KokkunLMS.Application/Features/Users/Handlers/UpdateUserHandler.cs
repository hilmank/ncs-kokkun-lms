using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Commands;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.Constants;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<UpdateUserCommand> _validator;
    private readonly IFileStorageService _fileStorage;
    private readonly ICurrentUserService _currentUser;
    public UpdateUserHandler(
        IUnitOfWork uow,
        IValidator<UpdateUserCommand> validator,
        IFileStorageService fileStorage,
        ICurrentUserService currentUser)
    {
        _uow = uow;
        _validator = validator;
        _fileStorage = fileStorage;
        _currentUser = currentUser;
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

        if (request.ProfilePicture is not null && request.ProfilePicture.Length > 0)
        {
            // Delete the old file (if not default)
            if (!string.IsNullOrEmpty(user.ProfilePicture))
            {
                await _fileStorage.DeleteFileAsync(user.ProfilePicture, FileUploadFolders.ProfilePictures, cancellationToken);
            }
            // Save new file
            var newFileName = await _fileStorage.SaveFileAsync(request.ProfilePicture, FileUploadFolders.ProfilePictures, cancellationToken);
            user.ProfilePicture = newFileName;
        }

        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = _currentUser.UserId;

        return await _uow.Users.UpdateProfileAsync(user);
    }
}
