namespace KokkunLMS.Shared.DTOs.Course;

public class CreateCourseDto
{
    public string Title { get; set; } = null!;
    public string PaketLevel { get; set; } = null!;
    public string GradeLevel { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public int TeacherId { get; set; }
}
