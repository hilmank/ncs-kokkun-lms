namespace KokkunLMS.Shared.DTOs.Lesson;

public class LessonDto
{
    public int LessonId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? VideoUrl { get; set; }
    public string? DocumentUrl { get; set; }
    public string CreatedAt { get; set; } = null!;
}
