using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(Lesson lesson);
    }
}
