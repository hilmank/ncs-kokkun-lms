namespace KokkunLMS.Domain.Entities
{
    public class QuizSubmission
    {
        public int SubmissionId { get; set; }
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public decimal Score { get; set; }
        public DateTime SubmittedAt { get; set; }

        public Quiz? Quiz { get; set; }
        public User? Student { get; set; }
    }
}
