using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class ParentStudentRepository : IParentStudentRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public ParentStudentRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<int>> GetChildrenIdsByParentIdAsync(int parentId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<int>(
            ParentsstudentsQueries.GetChildrenIdsByParentId,
            new { ParentId = parentId }
        );
    }
}
