using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IPerformanceReportRepository
    {
        Task<IEnumerable<PerformanceReport>> GetByStudentIdAsync(int studentId);
        Task<int> GenerateReportAsync(PerformanceReport report);
    }
}
