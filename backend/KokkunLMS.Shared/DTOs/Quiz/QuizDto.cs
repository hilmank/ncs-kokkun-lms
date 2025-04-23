namespace KokkunLMS.Shared.DTOs.Quizzes;

public class QuizDto
{
    public int QuizId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
}
