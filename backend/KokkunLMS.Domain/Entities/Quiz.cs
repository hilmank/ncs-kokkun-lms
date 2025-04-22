namespace KokkunLMS.Domain.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Course? Course { get; set; }
        public List<QuizQuestion>? Questions { get; set; }
        public List<QuizSubmission>? Submissions { get; set; }
    }
}
