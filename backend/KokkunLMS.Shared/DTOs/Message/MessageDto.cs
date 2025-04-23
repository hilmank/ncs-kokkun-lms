namespace KokkunLMS.Shared.DTOs.Message;

public class MessageDto
{
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public string SenderName { get; set; } = null!; // Optional
    public int ReceiverId { get; set; }
    public string ReceiverName { get; set; } = null!; // Optional
    public string Content { get; set; } = null!;
    public string SentAt { get; set; } = null!;
    public bool IsRead { get; set; }
}
