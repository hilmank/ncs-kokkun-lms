using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesBetweenAsync(int senderId, int receiverId);
        Task<int> SendMessageAsync(Message message);
        Task MarkAsReadAsync(int messageId);
    }
}
