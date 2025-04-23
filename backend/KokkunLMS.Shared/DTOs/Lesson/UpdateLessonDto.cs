namespace KokkunLMS.Shared.DTOs.Lesson;

public class UpdateLessonDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? VideoUrl { get; set; }
    public string? DocumentUrl { get; set; }
}
