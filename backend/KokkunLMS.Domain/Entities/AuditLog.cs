namespace KokkunLMS.Domain.Entities
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public string ActionType { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime AuditLogTimestamp { get; set; }
        public string EntityName { get; set; } = default!;
        public int EntityId { get; set; }
        public string? OldData { get; set; } // stored as JSON
        public string IpAddress { get; set; } = default!;
        public DateTime TimesAction { get; set; }
    }
}
