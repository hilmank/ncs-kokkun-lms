using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetByStudentIdAsync(int studentId);
        Task<int> MarkAttendanceAsync(Attendance attendance);
    }
}
