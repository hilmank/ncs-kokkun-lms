using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IDiscussionReplyRepository
    {
        Task<IEnumerable<DiscussionReply>> GetByThreadIdAsync(int threadId);
        Task<int> ReplyAsync(DiscussionReply reply);
    }
}
