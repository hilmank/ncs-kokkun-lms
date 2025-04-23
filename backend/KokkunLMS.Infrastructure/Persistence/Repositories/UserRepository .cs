using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public UserRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        var userId = await connection.ExecuteScalarAsync<int>(UsersQueries.Insert, user);
        return userId;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = UsersQueries.BaseSelect;
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = UsersQueries.BaseSelect + " WHERE users.email = @Email";
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = UsersQueries.BaseSelect + " WHERE users.userid = @UserId";
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { UserId = userId });
    }

    public async Task<bool> UpdateProfileAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync(UsersQueries.Update, user);
        return result > 0;
    }
}
