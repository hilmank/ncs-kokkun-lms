using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface ITeacherFeedbackRepository
    {
        Task<IEnumerable<TeacherFeedback>> GetByTeacherIdAsync(int teacherId);
        Task<int> SubmitFeedbackAsync(TeacherFeedback feedback);
    }
}
