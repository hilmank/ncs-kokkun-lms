using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(Schedule schedule);
    }
}
