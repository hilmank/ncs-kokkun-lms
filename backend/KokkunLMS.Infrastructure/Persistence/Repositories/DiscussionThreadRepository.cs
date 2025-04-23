using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class DiscussionThreadRepository : IDiscussionThreadRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public DiscussionThreadRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<DiscussionThread>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<DiscussionThread>(
            DiscussionthreadsQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(DiscussionThread thread)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            DiscussionthreadsQueries.Insert,
            thread
        );
    }
}
