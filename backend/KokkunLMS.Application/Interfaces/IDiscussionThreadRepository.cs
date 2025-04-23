using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IDiscussionThreadRepository
    {
        Task<IEnumerable<DiscussionThread>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(DiscussionThread thread);
    }
}
