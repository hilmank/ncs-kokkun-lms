using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public CourseRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Course>(CoursesQueries.BaseSelect);
    }

    public async Task<Course?> GetByIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Course>(
            CoursesQueries.GetById,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(Course course)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            CoursesQueries.Insert,
            course
        );
    }
}
