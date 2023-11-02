using Npgsql;
using System.Data;

namespace Pagination.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        }
    }
}
