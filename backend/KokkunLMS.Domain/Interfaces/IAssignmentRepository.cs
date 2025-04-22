using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(Assignment assignment);
    }
}
