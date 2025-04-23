namespace KokkunLMS.Shared.DTOs.AssignmentSubmission;

public class GradeAssignmentDto
{
    public int SubmissionId { get; set; }
    public float Grade { get; set; }
    public string Feedback { get; set; } = null!;
}
