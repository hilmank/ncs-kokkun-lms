using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IDiscussionThreadRepository
    {
        Task<IEnumerable<DiscussionThread>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(DiscussionThread thread);
    }
}
