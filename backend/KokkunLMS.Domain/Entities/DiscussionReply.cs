namespace KokkunLMS.Domain.Entities
{
    public class DiscussionReply
    {
        public int ReplyId { get; set; }
        public int ThreadId { get; set; }
        public int RepliedBy { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public DiscussionThread? Thread { get; set; }
        public User? RepliedByUser { get; set; }
    }
}
