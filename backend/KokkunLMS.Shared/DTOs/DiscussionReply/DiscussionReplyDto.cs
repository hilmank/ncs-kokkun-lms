namespace KokkunLMS.Shared.DTOs.DiscussionReply;

public class DiscussionReplyDto
{
    public int ReplyId { get; set; }
    public int ThreadId { get; set; }
    public int RepliedBy { get; set; }
    public string RepliedByName { get; set; } = null!; // Optional
    public string Content { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
}
