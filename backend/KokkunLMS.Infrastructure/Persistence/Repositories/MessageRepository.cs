using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public MessageRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Message>> GetMessagesBetweenAsync(int senderId, int receiverId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Message>(
            MessagesQueries.GetMessagesBetween,
            new { SenderId = senderId, ReceiverId = receiverId }
        );
    }

    public async Task<int> SendMessageAsync(Message message)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            MessagesQueries.Insert,
            message
        );
    }

    public async Task MarkAsReadAsync(int messageId)
    {
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(MessagesQueries.MarkAsRead, new { MessageId = messageId });
    }
}
