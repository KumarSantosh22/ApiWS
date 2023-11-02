using Dapper;
using Pagination.Data;
using System.Data;

namespace Pagination.Services
{
    public class StoredProcedure
    {
        private IDbConnection db { get; set; }

        public StoredProcedure(DapperDbContext dapper)
        {
            this.db = dapper.CreateConnection();
        }

        public async Task<IEnumerable<T>> ExecuteProcedure<T>(string query, object param)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            return await db.QueryAsync<T>(query, param);
        }
    }
}
