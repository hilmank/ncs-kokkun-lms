using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public QuizRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Quiz>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Quiz>(
            QuizzesQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(Quiz quiz)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            QuizzesQueries.Insert,
            quiz
        );
    }
}
