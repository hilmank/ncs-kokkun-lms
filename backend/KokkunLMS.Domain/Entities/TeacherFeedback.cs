namespace KokkunLMS.Domain.Entities
{
    public class TeacherFeedback
    {
        public int FeedbackId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Rating { get; set; }
        public required string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? Teacher { get; set; }
        public User? Student { get; set; }
        public Course? Course { get; set; }
    }
}
