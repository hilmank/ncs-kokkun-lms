using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetByStudentIdAsync(int studentId);
        Task<int> MarkAttendanceAsync(Attendance attendance);
    }
}
