using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IContentApprovalRepository
    {
        Task<IEnumerable<ContentApproval>> GetPendingApprovalsAsync();
        Task<int> SubmitContentAsync(ContentApproval approval);
        Task<bool> ReviewContentAsync(int approvalId, int reviewedby, string status, string? notes);
    }
}
