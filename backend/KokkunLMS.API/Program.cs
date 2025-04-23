using KokkunLMS.Infrastructure.Services;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Infrastructure.Persistence;
using KokkunLMS.Infrastructure.Persistence.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Register the Factory in DI
builder.Services.AddSingleton<DapperConnectionFactory>();

// ✅ Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAssignmentSubmissionRepository, AssignmentSubmissionRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IContentApprovalRepository, ContentApprovalRepository>();
builder.Services.AddScoped<IDiscussionReplyRepository, DiscussionReplyRepository>();
builder.Services.AddScoped<IDiscussionThreadRepository, DiscussionThreadRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IParentStudentRepository, ParentStudentRepository>();
builder.Services.AddScoped<IPerformanceReportRepository, PerformanceReportRepository>();
builder.Services.AddScoped<IQuizQuestionRepository, QuizQuestionRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizSubmissionRepository, QuizSubmissionRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ITeacherFeedbackRepository, TeacherFeedbackRepository>();

// ✅ Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
