using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class TeacherFeedbackRepository : ITeacherFeedbackRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public TeacherFeedbackRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TeacherFeedback>> GetByTeacherIdAsync(int teacherId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<TeacherFeedback>(
            TeacherfeedbackQueries.GetByTeacherId,
            new { TeacherId = teacherId }
        );
    }

    public async Task<int> SubmitFeedbackAsync(TeacherFeedback feedback)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            TeacherfeedbackQueries.Insert,
            feedback
        );
    }
}
