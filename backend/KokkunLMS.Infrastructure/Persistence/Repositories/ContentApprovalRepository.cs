using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class ContentApprovalRepository : IContentApprovalRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public ContentApprovalRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<ContentApproval>> GetPendingApprovalsAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<ContentApproval>(ContentapprovalQueries.GetPending);
    }

    public async Task<int> SubmitContentAsync(ContentApproval approval)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            ContentapprovalQueries.Insert,
            approval
        );
    }

    public async Task<bool> ReviewContentAsync(int approvalId, int reviewedby, string status, string? notes)
    {
        using var connection = _connectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync(
            ContentapprovalQueries.Review,
            new
            {
                ApprovalId = approvalId,
                Status = status,
                ReviewNotes = notes,
                ReviewedBy = reviewedby,
                ReviewedAt = DateTime.UtcNow
            }
        );

        return result > 0;
    }
}
