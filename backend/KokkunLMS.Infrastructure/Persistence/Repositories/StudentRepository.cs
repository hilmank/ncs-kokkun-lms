using System;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public StudentRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateAsync(Student student)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(StudentsQueries.Insert, student);
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        using var connection = _connectionFactory.CreateConnection();
        var affectedRows = await connection.ExecuteAsync(StudentsQueries.Update, student);
        return affectedRows > 0;
    }

    public async Task<Student?> GetByUserIdAsync(int userId)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"{StudentsQueries.BaseSelect} WHERE {StudentsQueries.Table}.userid = @UserId";

        return await connection.QueryFirstOrDefaultAsync<Student>(sql, new { UserId = userId });
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = StudentsQueries.BaseSelect;

        return await connection.QueryAsync<Student>(sql);
    }
}

