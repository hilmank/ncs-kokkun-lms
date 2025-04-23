using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public AssignmentSubmissionRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<AssignmentSubmission>(
            AssignmentsubmissionsQueries.GetByAssignmentId,
            new { AssignmentId = assignmentId }
        );
    }

    public async Task<int> SubmitAsync(AssignmentSubmission submission)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            AssignmentsubmissionsQueries.Insert,
            submission
        );
    }

    public async Task<bool> GradeSubmissionAsync(int submissionId, decimal grade, string feedback)
    {
        using var connection = _connectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync(
            AssignmentsubmissionsQueries.GradeSubmission,
            new { SubmissionId = submissionId, Grade = grade, Feedback = feedback }
        );
        return result > 0;
    }
}
