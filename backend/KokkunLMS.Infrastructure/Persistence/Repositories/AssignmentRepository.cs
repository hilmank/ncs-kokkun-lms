using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public AssignmentRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Assignment>(
            AssignmentsQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(Assignment assignment)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            AssignmentsQueries.Insert,
            assignment
        );
    }
}
