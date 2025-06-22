using MediatR;
using Microsoft.AspNetCore.Http;

namespace KokkunLMS.Application.Features.Users.Commands;

public class UpdateUserProfileCommand : IRequest<bool>
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public IFormFile? ProfilePicture { get; set; }
}
