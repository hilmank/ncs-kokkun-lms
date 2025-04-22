using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IContentApprovalRepository
    {
        Task<IEnumerable<ContentApproval>> GetPendingApprovalsAsync();
        Task<int> SubmitContentAsync(ContentApproval approval);
        Task<bool> ReviewContentAsync(int approvalId, string status, string? notes);
    }
}
