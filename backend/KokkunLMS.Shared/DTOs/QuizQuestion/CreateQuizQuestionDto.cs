namespace KokkunLMS.Shared.DTOs.QuizQuestion;

public class CreateQuizQuestionDto
{
    public int QuizId { get; set; }
    public string QuestionText { get; set; } = null!;
    public string QuestionType { get; set; } = null!; // e.g., "Multiple Choice", "Short Answer"
    public string Options { get; set; } = null!; // JSON string format for options (if applicable)
    public string CorrectAnswer { get; set; } = null!;
    public int Points { get; set; }
}
