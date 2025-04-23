using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetByCourseIdAsync(int courseId);
        Task<int> PostAnnouncementAsync(Announcement announcement);
    }
}
