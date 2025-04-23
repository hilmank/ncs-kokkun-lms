using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class PerformanceReportRepository : IPerformanceReportRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public PerformanceReportRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<PerformanceReport>> GetByStudentIdAsync(int studentId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<PerformanceReport>(
            PerformancereportsQueries.GetByStudentId,
            new { StudentId = studentId }
        );
    }

    public async Task<int> GenerateReportAsync(PerformanceReport report)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            PerformancereportsQueries.Insert,
            report
        );
    }
}
