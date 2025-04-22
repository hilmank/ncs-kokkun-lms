namespace KokkunLMS.Domain.Entities
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public int? CourseId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int PostedBy { get; set; }
        public DateTime PostedAt { get; set; }

        public Course? Course { get; set; }
        public User? PostedByUser { get; set; }
    }
}
