using Pagination.Models;

namespace Pagination.Services.Contracts
{
    public interface ITicketDapperService
    {
        Task<List<Ticket>> GetAllAsync();
    }
}