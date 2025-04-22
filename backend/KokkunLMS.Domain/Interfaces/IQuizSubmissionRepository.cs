using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IQuizSubmissionRepository
    {
        Task<int> SubmitQuizAsync(QuizSubmission submission);
        Task<IEnumerable<QuizSubmission>> GetByStudentIdAsync(int studentId);
    }
}
