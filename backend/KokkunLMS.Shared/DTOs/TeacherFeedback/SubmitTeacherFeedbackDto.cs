namespace KokkunLMS.Shared.DTOs.TeacherFeedback;

public class SubmitTeacherFeedbackDto
{
    public int TeacherId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int Rating { get; set; } // e.g., 1 to 5
    public string Comment { get; set; } = null!;
}
