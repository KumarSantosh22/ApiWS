using Pagination.Models;

namespace Pagination.Data.Contracts
{
    public interface IRepositoryDapper<T>
    {
        Task<List<T>> GetAllAsync(string query);
    }
}
