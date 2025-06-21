using KokkunLMS.Application.Interfaces;

namespace KokkunLMS.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; }
    public ICourseRepository Courses { get; }
    public IAssignmentRepository Assignments { get; }
    public IAnnouncementRepository Announcements { get; }
    public IAssignmentSubmissionRepository AssignmentSubmissions { get; }
    public IAttendanceRepository Attendance { get; }
    public IContentApprovalRepository ContentApprovals { get; }
    public IDiscussionReplyRepository DiscussionReplies { get; }
    public IDiscussionThreadRepository DiscussionThreads { get; }
    public ILessonRepository Lessons { get; }
    public IMessageRepository Messages { get; }
    public IParentStudentRepository ParentStudents { get; }
    public IPerformanceReportRepository PerformanceReports { get; }
    public IQuizQuestionRepository QuizQuestions { get; }
    public IQuizRepository Quizzes { get; }
    public IQuizSubmissionRepository QuizSubmissions { get; }
    public IRoleRepository Roles { get; }
    public IScheduleRepository Schedules { get; }
    public ITeacherFeedbackRepository TeacherFeedback { get; }
    public IStudentRepository Students { get; }
    public IGenderRepository Genders { get; }
    public ICourseClassRepository CourseClasses { get; }
    public UnitOfWork(
        IUserRepository users,
        ICourseRepository courses,
        IAssignmentRepository assignments,
        IAnnouncementRepository announcements,
        IAssignmentSubmissionRepository assignmentSubmissions,
        IAttendanceRepository attendance,
        IContentApprovalRepository contentApprovals,
        IDiscussionReplyRepository discussionReplies,
        IDiscussionThreadRepository discussionThreads,
        ILessonRepository lessons,
        IMessageRepository messages,
        IParentStudentRepository parentStudents,
        IPerformanceReportRepository performanceReports,
        IQuizQuestionRepository quizQuestions,
        IQuizRepository quizzes,
        IQuizSubmissionRepository quizSubmissions,
        IRoleRepository roles,
        IScheduleRepository schedules,
        ITeacherFeedbackRepository teacherFeedback,
        IStudentRepository students,
        IGenderRepository genders,
        ICourseClassRepository courseClasses
    )
    {
        Users = users;
        Courses = courses;
        Assignments = assignments;
        Announcements = announcements;
        AssignmentSubmissions = assignmentSubmissions;
        Attendance = attendance;
        ContentApprovals = contentApprovals;
        DiscussionReplies = discussionReplies;
        DiscussionThreads = discussionThreads;
        Lessons = lessons;
        Messages = messages;
        ParentStudents = parentStudents;
        PerformanceReports = performanceReports;
        QuizQuestions = quizQuestions;
        Quizzes = quizzes;
        QuizSubmissions = quizSubmissions;
        Roles = roles;
        Schedules = schedules;
        TeacherFeedback = teacherFeedback;
        Students = students;
        Genders = genders;
        CourseClasses = courseClasses;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Dapper is stateless, so we return 0 (or could remove if unused)
        return Task.FromResult(0);
    }
}
