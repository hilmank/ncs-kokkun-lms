using MediatR;
using Microsoft.AspNetCore.Http;

namespace KokkunLMS.Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public int UserId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? RoleId { get; set; }

    public IFormFile? ProfilePicture { get; set; }
}
