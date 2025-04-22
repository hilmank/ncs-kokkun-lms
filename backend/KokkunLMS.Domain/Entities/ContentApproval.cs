namespace KokkunLMS.Domain.Entities
{
    public class ContentApproval
    {
        public int ApprovalId { get; set; }
        public required string ContentType { get; set; }
        public int ContentId { get; set; }
        public int SubmittedBy { get; set; }
        public required string Status { get; set; }
        public int? ReviewedBy { get; set; }
        public string? ReviewNotes { get; set; }
        public DateTime? ReviewedAt { get; set; }

        public User? SubmittedByUser { get; set; }
        public User? ReviewedByUser { get; set; }
    }
}
