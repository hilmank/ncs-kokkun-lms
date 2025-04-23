namespace KokkunLMS.Shared.DTOs.Users;

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ProfilePicture { get; set; } = null!;
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!; // Optional
    public string CreatedAt { get; set; } = null!;
}
