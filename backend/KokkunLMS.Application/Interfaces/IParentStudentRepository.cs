using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IParentStudentRepository
    {
        Task<IEnumerable<int>> GetChildrenIdsByParentIdAsync(int parentId);
        Task LinkAsync(int parentId, int studentId);
    }
}
