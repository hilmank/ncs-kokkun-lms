using System;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class GenderRepository : IGenderRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public GenderRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Gender>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Gender>(GendersQueries.BaseSelect);
    }

    public async Task<Gender?> GetByCodeAsync(string code)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = $"{GendersQueries.BaseSelect} WHERE {GendersQueries.Table}.code = @Code";
        return await connection.QueryFirstOrDefaultAsync<Gender>(sql, new { Code = code });
    }

}

