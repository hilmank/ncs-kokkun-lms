using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class DiscussionReplyRepository : IDiscussionReplyRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public DiscussionReplyRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<DiscussionReply>> GetByThreadIdAsync(int threadId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<DiscussionReply>(
            DiscussionrepliesQueries.GetByThreadId,
            new { ThreadId = threadId }
        );
    }

    public async Task<int> ReplyAsync(DiscussionReply reply)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            DiscussionrepliesQueries.Insert,
            reply
        );
    }
}
