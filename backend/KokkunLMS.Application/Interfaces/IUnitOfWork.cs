namespace KokkunLMS.Application.Interfaces;

public interface IUnitOfWork
{
    IAnnouncementRepository Announcements { get; }
    IAssignmentRepository Assignments { get; }
    IAssignmentSubmissionRepository AssignmentSubmissions { get; }
    IAttendanceRepository Attendance { get; }
    IContentApprovalRepository ContentApprovals { get; }
    ICourseRepository Courses { get; }
    IDiscussionReplyRepository DiscussionReplies { get; }
    IDiscussionThreadRepository DiscussionThreads { get; }
    ILessonRepository Lessons { get; }
    IMessageRepository Messages { get; }
    IParentStudentRepository ParentStudents { get; }
    IPerformanceReportRepository PerformanceReports { get; }
    IQuizQuestionRepository QuizQuestions { get; }
    IQuizRepository Quizzes { get; }
    IQuizSubmissionRepository QuizSubmissions { get; }
    IRoleRepository Roles { get; }
    IScheduleRepository Schedules { get; }
    ITeacherFeedbackRepository TeacherFeedback { get; }
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
