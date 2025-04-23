namespace KokkunLMS.Shared.DTOs.Lesson;

public class CreateLessonDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? VideoUrl { get; set; }
    public string? DocumentUrl { get; set; }
}
