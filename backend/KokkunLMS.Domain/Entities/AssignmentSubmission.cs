namespace KokkunLMS.Domain.Entities
{
    public class AssignmentSubmission
    {
        public int SubmissionId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string? FileUrl { get; set; }
        public DateTime SubmittedAt { get; set; }
        public decimal Grade { get; set; }
        public required string Feedback { get; set; }

        public Assignment? Assignment { get; set; }
        public User? Student { get; set; }
    }
}
