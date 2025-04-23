using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class QuizSubmissionRepository : IQuizSubmissionRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public QuizSubmissionRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> SubmitQuizAsync(QuizSubmission submission)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            QuizsubmissionsQueries.Insert,
            submission
        );
    }

    public async Task<IEnumerable<QuizSubmission>> GetByStudentIdAsync(int studentId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<QuizSubmission>(
            QuizsubmissionsQueries.GetByStudentId,
            new { StudentId = studentId }
        );
    }
}
