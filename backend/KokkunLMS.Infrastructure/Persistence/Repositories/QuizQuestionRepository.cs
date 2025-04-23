using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class QuizQuestionRepository : IQuizQuestionRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public QuizQuestionRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<QuizQuestion>> GetByQuizIdAsync(int quizId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<QuizQuestion>(
            QuizquestionsQueries.GetByQuizId,
            new { QuizId = quizId }
        );
    }

    public async Task<int> AddQuestionAsync(QuizQuestion question)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            QuizquestionsQueries.Insert,
            question
        );
    }
}
