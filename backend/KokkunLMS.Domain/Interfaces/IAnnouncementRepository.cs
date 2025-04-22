using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetByCourseIdAsync(int courseId);
        Task<int> PostAnnouncementAsync(Announcement announcement);
    }
}
