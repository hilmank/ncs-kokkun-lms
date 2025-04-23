namespace KokkunLMS.Shared.DTOs.DiscussionThread;

public class DiscussionThreadDto
{
    public int ThreadId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional
    public int CreatedBy { get; set; }
    public string CreatedByName { get; set; } = null!; // Optional
    public string Title { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
}
