namespace KokkunLMS.Shared.DTOs.DiscussionReply;

public class PostReplyDto
{
    public int ThreadId { get; set; }
    public int RepliedBy { get; set; }
    public string Content { get; set; } = null!;
}
