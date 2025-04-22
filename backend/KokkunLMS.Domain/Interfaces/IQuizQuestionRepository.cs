using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IQuizQuestionRepository
    {
        Task<IEnumerable<QuizQuestion>> GetByQuizIdAsync(int quizId);
        Task<int> AddQuestionAsync(QuizQuestion question);
    }
}
