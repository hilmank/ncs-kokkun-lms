using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public AnnouncementRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Announcement>> GetByCourseIdAsync(int courseId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Announcement>(
            AnnouncementsQueries.GetByCourseId,
            new { CourseId = courseId }
        );
    }

    public async Task<int> PostAnnouncementAsync(Announcement announcement)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(
            AnnouncementsQueries.Insert,
            announcement
        );
    }
}
