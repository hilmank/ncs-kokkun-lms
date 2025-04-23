namespace KokkunLMS.Shared.DTOs.Assignment;

public class AssignmentDto
{
    public int AssignmentId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // optional, for display
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string DueDate { get; set; } = null!;
    public string? AttachmentUrl { get; set; }
    public string CreatedAt { get; set; } = null!;
}
