namespace KokkunLMS.Shared.DTOs.AssignmentSubmission;

public class AssignmentSubmissionDto
{
    public int SubmissionId { get; set; }
    public int AssignmentId { get; set; }
    public string AssignmentTitle { get; set; } = null!; // optional
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!; // optional
    public string FileUrl { get; set; } = null!;
    public string SubmittedAt { get; set; } = null!;
    public float Grade { get; set; }
    public string Feedback { get; set; } = null!;
}
