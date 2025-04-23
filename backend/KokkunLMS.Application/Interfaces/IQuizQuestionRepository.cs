using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IQuizQuestionRepository
    {
        Task<IEnumerable<QuizQuestion>> GetByQuizIdAsync(int quizId);
        Task<int> AddQuestionAsync(QuizQuestion question);
    }
}
