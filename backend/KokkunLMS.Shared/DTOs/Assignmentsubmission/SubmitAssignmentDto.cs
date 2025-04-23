namespace KokkunLMS.Shared.DTOs.AssignmentSubmission;

public class SubmitAssignmentDto
{
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public string FileUrl { get; set; } = null!;
}
