namespace KokkunLMS.Domain.Entities
{
    public class QuizQuestion
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public required string QuestionText { get; set; }
        public required string QuestionType { get; set; }
        public string? Options { get; set; } // stored as JSON
        public required string CorrectAnswer { get; set; }
        public int Points { get; set; }

        public Quiz? Quiz { get; set; }
    }
}
