namespace KokkunLMS.Shared.DTOs.User;

public class RegisterUserDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ProfilePicture { get; set; } = null!;
    public int RoleId { get; set; }
}
