using Dapper;
using Pagination.Data.Contracts;
using System.Data;

namespace Pagination.Data
{
    public class RepositoryDapper<T> : IRepositoryDapper<T>
    {
        private IDbConnection db { get; set; }

        public RepositoryDapper(DapperDbContext dapper)
        {
            this.db = dapper.CreateConnection();
        }

        public async Task<List<T>> GetAllAsync(string query)
        {
            return (await db.QueryAsync<T>(query)).ToList();
        }

        public async Task AsyncAdd(string query)
        {
            _ = (await db.QueryAsync<T>(query));
        }
    }
}
