using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public ScheduleRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Schedule>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Schedule>(
            SchedulesQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> CreateAsync(Schedule schedule)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            SchedulesQueries.Insert,
            schedule
        );
    }
}
