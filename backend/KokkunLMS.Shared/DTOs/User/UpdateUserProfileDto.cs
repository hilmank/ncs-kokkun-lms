namespace KokkunLMS.Shared.DTOs.User;

public class UpdateUserProfileDto
{
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ProfilePicture { get; set; } = null!;
}
