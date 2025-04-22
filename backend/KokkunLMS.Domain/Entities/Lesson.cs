namespace KokkunLMS.Domain.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? DocumentUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public Course? Course { get; set; }
    }
}
