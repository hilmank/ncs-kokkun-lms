namespace KokkunLMS.Shared.DTOs.Quiz;

public class CreateQuizDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
