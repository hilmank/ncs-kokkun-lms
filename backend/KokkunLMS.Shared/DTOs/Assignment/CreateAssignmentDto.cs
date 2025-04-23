namespace KokkunLMS.Shared.DTOs.Assignment;

public class CreateAssignmentDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string DueDate { get; set; } = null!; // ISO 8601 string
    public string? AttachmentUrl { get; set; }
}
