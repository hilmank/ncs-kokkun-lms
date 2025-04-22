namespace KokkunLMS.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public required string PaketLevel { get; set; }
        public required string GradeLevel { get; set; }
        public required string Subject { get; set; }
        public int TeacherId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? Teacher { get; set; }

        public List<Assignment>? Assignments { get; set; }
        public List<Lesson>? Lessons { get; set; }
        public List<Quiz>? Quizzes { get; set; }
        public List<DiscussionThread>? DiscussionThreads { get; set; }
        public List<Schedule>? Schedules { get; set; }
        public List<Announcement>? Announcements { get; set; }
        public List<TeacherFeedback>? Feedbacks { get; set; }
    }
}
