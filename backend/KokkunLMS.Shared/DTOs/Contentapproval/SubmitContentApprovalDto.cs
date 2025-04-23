namespace KokkunLMS.Shared.DTOs.ContentApproval;

public class SubmitContentApprovalDto
{
    public string ContentType { get; set; } = null!; // e.g., "Lesson", "Assignment"
    public int ContentId { get; set; }
    public int SubmittedBy { get; set; }
}
