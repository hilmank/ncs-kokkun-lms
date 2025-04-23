using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface ITeacherFeedbackRepository
    {
        Task<IEnumerable<TeacherFeedback>> GetByTeacherIdAsync(int teacherId);
        Task<int> SubmitFeedbackAsync(TeacherFeedback feedback);
    }
}
