using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
        Task<int> CreateAsync(Assignment assignment);
    }
}
