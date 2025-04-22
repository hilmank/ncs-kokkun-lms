using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IParentStudentRepository
    {
        Task<IEnumerable<int>> GetChildrenIdsByParentIdAsync(int parentId);
    }
}
