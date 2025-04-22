using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Domain.Interfaces
{
    public interface IDiscussionReplyRepository
    {
        Task<IEnumerable<DiscussionReply>> GetByThreadIdAsync(int threadId);
        Task<int> ReplyAsync(DiscussionReply reply);
    }
}
