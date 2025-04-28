using MediatR;

namespace KokkunLMS.Application.Commands.Courses
{
    public record CreateCourseCommand(
        string Title,
        string PaketLevel,   // "Paket A", "Paket B", or "Paket C"
        string GradeLevel,   // e.g., "Grade 1", "Grade 2"
        string Subject,      // e.g., "Math", "Science"
        int TeacherId        // The userId of the teacher creating this course
    ) : IRequest<int>;
}
