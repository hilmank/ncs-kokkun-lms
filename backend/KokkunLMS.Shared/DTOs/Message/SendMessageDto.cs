namespace KokkunLMS.Shared.DTOs.Message;

public class SendMessageDto
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Content { get; set; } = null!;
}
