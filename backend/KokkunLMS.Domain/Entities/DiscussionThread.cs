namespace KokkunLMS.Domain.Entities
{
    public class DiscussionThread
    {
        public int ThreadId { get; set; }
        public int CourseId { get; set; }
        public int CreatedBy { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public Course? Course { get; set; }
        public User? CreatedByUser { get; set; }
        public List<DiscussionReply>? Replies { get; set; }
    }
}
