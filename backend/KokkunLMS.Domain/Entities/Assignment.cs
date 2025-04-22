namespace KokkunLMS.Domain.Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public Course? Course { get; set; }
        public List<AssignmentSubmission>? Submissions { get; set; }
    }
}
