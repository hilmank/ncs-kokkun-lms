namespace KokkunLMS.Shared.DTOs.Announcement;

public class CreateAnnouncementDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int PostedBy { get; set; }
}