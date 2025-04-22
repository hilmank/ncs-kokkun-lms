using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IPerformanceReportRepository
    {
        Task<IEnumerable<PerformanceReport>> GetByStudentIdAsync(int studentId);
        Task<int> GenerateReportAsync(PerformanceReport report);
    }
}
