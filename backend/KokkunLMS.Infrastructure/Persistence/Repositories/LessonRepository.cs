using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public LessonRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Lesson>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Lesson>(
            LessonsQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(Lesson lesson)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            LessonsQueries.Insert,
            lesson
        );
    }
}
