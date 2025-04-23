using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(Quiz quiz);
    }
}
