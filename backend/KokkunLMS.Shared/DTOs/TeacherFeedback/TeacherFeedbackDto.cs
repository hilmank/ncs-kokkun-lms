namespace KokkunLMS.Shared.DTOs.TeacherFeedback;

public class TeacherFeedbackDto
{
    public int FeedbackId { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = null!; // Optional
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!; // Optional
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
}
