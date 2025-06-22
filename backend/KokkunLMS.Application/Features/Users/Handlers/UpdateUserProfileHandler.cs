using FluentValidation;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Commands;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.Constants;
using MediatR;

namespace KokkunLMS.Application.Features.Users.Handlers;

public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, bool>
{
    private readonly IUnitOfWork _uow;
    private readonly IValidator<UpdateUserProfileCommand> _validator;
    private readonly IFileStorageService _fileStorage;
    private readonly ICurrentUserService _currentUser;

    public UpdateUserProfileHandler(
        IUnitOfWork uow,
        IValidator<UpdateUserProfileCommand> validator,
        IFileStorageService fileStorage,
        ICurrentUserService currentUser)
    {
        _uow = uow;
        _validator = validator;
        _fileStorage = fileStorage;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        if (!_currentUser.UserId.HasValue)
            throw new UnauthorizedAccessException("User not authenticated.");

        var user = await _uow.Users.GetByIdAsync(_currentUser.UserId.Value);
        if (user is null)
            throw new NotFoundException("User not found.");

        if (!string.IsNullOrWhiteSpace(request.FullName))
            user.FullName = request.FullName;

        if (!string.IsNullOrWhiteSpace(request.Email))
            user.Email = request.Email;

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            user.PhoneNumber = request.PhoneNumber;

        if (request.ProfilePicture is not null && request.ProfilePicture.Length > 0)
        {
            // Delete the old file (if not default)
            if (!string.IsNullOrEmpty(user.ProfilePicture))
            {
                await _fileStorage.DeleteFileAsync(user.ProfilePicture, FileUploadFolders.ProfilePictures, cancellationToken);
            }
            // Save new file
            var fileName = await _fileStorage.SaveFileAsync(request.ProfilePicture, FileUploadFolders.ProfilePictures, cancellationToken);
            user.ProfilePicture = fileName;
        }
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = _currentUser.UserId;

        return await _uow.Users.UpdateProfileAsync(user);
    }
}
