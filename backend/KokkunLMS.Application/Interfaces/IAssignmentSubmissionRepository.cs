using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IAssignmentSubmissionRepository
    {
        Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId);
        Task<int> SubmitAsync(AssignmentSubmission submission);
        Task<bool> GradeSubmissionAsync(int submissionId, decimal grade, string feedback);
    }
}
