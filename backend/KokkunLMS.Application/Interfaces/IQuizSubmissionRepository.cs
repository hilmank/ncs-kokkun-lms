using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IQuizSubmissionRepository
    {
        Task<int> SubmitQuizAsync(QuizSubmission submission);
        Task<IEnumerable<QuizSubmission>> GetByStudentIdAsync(int studentId);
    }
}
