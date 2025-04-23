namespace KokkunLMS.Shared.DTOs.ContentApproval;

public class ContentApprovalDto
{
    public int ApprovalId { get; set; }
    public string ContentType { get; set; } = null!;
    public int ContentId { get; set; }
    public int SubmittedBy { get; set; }
    public string SubmittedByName { get; set; } = null!; // Optional
    public string Status { get; set; } = null!;
    public int? ReviewedBy { get; set; }
    public string? ReviewedByName { get; set; } // Optional
    public string? ReviewNotes { get; set; }
    public string? ReviewedAt { get; set; } // ISO 8601 string
}
