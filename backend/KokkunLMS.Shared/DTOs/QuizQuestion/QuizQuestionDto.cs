namespace KokkunLMS.Shared.DTOs.QuizQuestion;

public class QuizQuestionDto
{
    public int QuestionId { get; set; }
    public int QuizId { get; set; }
    public string QuestionText { get; set; } = null!;
    public string QuestionType { get; set; } = null!;
    public string Options { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public int Points { get; set; }
}
