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
    private static string BuildUserWithRoleQuery(string? condition = null)
    {
        var baseQuery = $@"
        SELECT 
            {UsersQueries.AllColumns},
            {RolesQueries.AllColumns}
        FROM {UsersQueries.Table}
        LEFT JOIN {RolesQueries.Table} ON {UsersQueries.Table}.roleid = {RolesQueries.Table}.roleid
        WHERE {UsersQueries.Table}.isdeleted = false
    ";

        if (!string.IsNullOrWhiteSpace(condition))
            baseQuery += $" AND {condition}";

        return baseQuery;
    }

    public async Task<int> CreateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(UsersQueries.Insert, user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = BuildUserWithRoleQuery();

        var result = await connection.QueryAsync<User, Role, User>(
            sql,
            (user, role) => { user.Role = role; return user; },
            splitOn: "RoleId"
        );

        return result;
    }

    public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = BuildUserWithRoleQuery($"({UsersQueries.Table}.username = @UsernameOrEmail OR {UsersQueries.Table}.email = @UsernameOrEmail)");

        var result = await connection.QueryAsync<User, Role, User>(
            sql,
            (user, role) =>
            {
                user.Role = role;
                return user;
            },
            new { UsernameOrEmail = usernameOrEmail },
            splitOn: "RoleId"
        );

        return result.FirstOrDefault();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = BuildUserWithRoleQuery($"{UsersQueries.Table}.userid = @UserId");

        var result = await connection.QueryAsync<User, Role, User>(
            sql,
            (user, role) => { user.Role = role; return user; },
            new { UserId = userId },
            splitOn: "RoleId"
        );

        return result.FirstOrDefault();
    }
    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = BuildUserWithRoleQuery($"{UsersQueries.Table}.refreshtoken = @RefreshToken");

        var result = await connection.QueryAsync<User, Role, User>(
            sql,
            (user, role) => { user.Role = role; return user; },
            new { RefreshToken = refreshToken },
            splitOn: "RoleId"
        );

        return result.FirstOrDefault();
    }

    public async Task<bool> UpdateProfileAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        var affectedRows = await connection.ExecuteAsync(UsersQueries.Update, user);
        return affectedRows > 0;
    }

    public async Task<int> RegisterParentWithStudentAsync(User userParent, User userStudent, Student student)
    {
        using var connection = _connectionFactory.CreateOpenConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            var parentId = await connection.ExecuteScalarAsync<int>(UsersQueries.Insert, userParent, transaction);
            var studentId = await connection.ExecuteScalarAsync<int>(UsersQueries.Insert, userStudent, transaction);

            await connection.ExecuteAsync(ParentsstudentsQueries.Insert, new
            {
                Parentid = parentId,
                Studentid = studentId
            }, transaction);
            student.UserId = studentId;
            await connection.ExecuteAsync(StudentsQueries.Insert, student, transaction);
            transaction.Commit();
            return parentId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<int> AddChildForParentAsync(int parentId, User student)
    {
        using var connection = _connectionFactory.CreateOpenConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            var studentId = await connection.ExecuteScalarAsync<int>(UsersQueries.Insert, student, transaction);

            await connection.ExecuteAsync(ParentsstudentsQueries.Insert, new
            {
                Parentid = parentId,
                Studentid = studentId
            }, transaction);

            transaction.Commit();
            return studentId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
