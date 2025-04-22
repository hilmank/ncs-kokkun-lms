using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace KokkunLMS.Infrastructure.Services
{
    public class DapperConnectionFactory
    {
        private readonly string _connectionString;

        public DapperConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("DefaultConnection", "Connection string 'DefaultConnection' is not found.");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
