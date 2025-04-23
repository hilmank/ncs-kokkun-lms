using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public AttendanceRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Attendance>> GetByStudentIdAsync(int studentId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Attendance>(
            AttendanceQueries.GetByStudentId,
            new { StudentId = studentId }
        );
    }

    public async Task<int> MarkAttendanceAsync(Attendance attendance)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            AttendanceQueries.Insert,
            attendance
        );
    }
}
