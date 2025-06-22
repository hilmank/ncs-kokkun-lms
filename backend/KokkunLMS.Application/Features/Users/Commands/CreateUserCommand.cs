using MediatR;
using Microsoft.AspNetCore.Http;

namespace KokkunLMS.Application.Features.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public string Username { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int RoleId { get; set; }

    public IFormFile? ProfilePicture { get; set; }
}
