using System.Data;
using Dapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Infrastructure.Persistence.Queries;
using KokkunLMS.Infrastructure.Services;

namespace KokkunLMS.Infrastructure.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DapperConnectionFactory _connectionFactory;

    public RoleRepository(DapperConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Role>(RolesQueries.BaseSelect);
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Role>(
            RolesQueries.GetById,
            new { Id = id }
        );
    }
}
