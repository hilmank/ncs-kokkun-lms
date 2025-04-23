namespace KokkunLMS.Shared.DTOs.Course;

public class CourseDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string PaketLevel { get; set; } = null!;
    public string GradeLevel { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = null!; // Optional
    public string CreatedAt { get; set; } = null!; // ISO 8601 string
}
