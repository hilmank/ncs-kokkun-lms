namespace KokkunLMS.Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }

        public User? Sender { get; set; }
        public User? Receiver { get; set; }
    }
}
