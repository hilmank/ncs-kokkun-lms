using System;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class CourseClassRepository : ICourseClassRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public CourseClassRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<CourseClass>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<CourseClass>(CourseClassQueries.BaseSelect);
    }

    public async Task<CourseClass?> GetByCodeAsync(string code)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = $"{CourseClassQueries.BaseSelect} WHERE {CourseClassQueries.Table}.code = @Code";
        return await connection.QueryFirstOrDefaultAsync<CourseClass>(sql, new { Code = code });
    }

    public async Task<int> CreateAsync(CourseClass courseClass)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(CourseClassQueries.Insert, courseClass);
    }

    public async Task<bool> UpdateAsync(CourseClass courseClass)
    {
        using var connection = _connectionFactory.CreateConnection();
        var affected = await connection.ExecuteAsync(CourseClassQueries.Update, courseClass);
        return affected > 0;
    }
}

