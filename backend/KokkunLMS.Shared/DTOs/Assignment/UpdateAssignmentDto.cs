namespace KokkunLMS.Shared.DTOs.Assignment;

public class UpdateAssignmentDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string DueDate { get; set; } = null!;
    public string? AttachmentUrl { get; set; }
}
