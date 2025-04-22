namespace KokkunLMS.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PasswordHash { get; set; }
        public string? ProfilePicture { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Role? Role { get; set; }

        public List<Announcement>? AnnouncementsPosted { get; set; }
        public List<AssignmentSubmission>? Submissions { get; set; }
        public List<Attendance>? Attendances { get; set; }
        public List<Attendance>? CheckedAttendances { get; set; }
        public List<ContentApproval>? SubmittedContentApprovals { get; set; }
        public List<ContentApproval>? ReviewedContentApprovals { get; set; }
        public List<Course>? CoursesTaught { get; set; }
        public List<DiscussionThread>? CreatedThreads { get; set; }
        public List<DiscussionReply>? Replies { get; set; }
        public List<Message>? SentMessages { get; set; }
        public List<Message>? ReceivedMessages { get; set; }
        public List<ParentStudent>? AsParentLinks { get; set; }
        public List<ParentStudent>? AsStudentLinks { get; set; }
        public List<PerformanceReport>? Reports { get; set; }
        public List<QuizSubmission>? QuizSubmissions { get; set; }
        public List<TeacherFeedback>? FeedbackGiven { get; set; }
        public List<TeacherFeedback>? FeedbackReceived { get; set; }
    }
}
