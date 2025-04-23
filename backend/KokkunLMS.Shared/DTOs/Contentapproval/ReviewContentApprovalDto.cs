namespace KokkunLMS.Shared.DTOs.ContentApproval;

public class ReviewContentApprovalDto
{
    public int ApprovalId { get; set; }
    public int ReviewedBy { get; set; }
    public string Status { get; set; } = null!; // e.g., "Approved", "Rejected"
    public string? ReviewNotes { get; set; }
}
