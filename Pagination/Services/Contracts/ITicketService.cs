using Pagination.Models;
using Pagination.Models.Filters;
using Sieve.Models;

namespace Pagination.Services.Contracts
{
    public interface ITicketService
    {
        Result<List<Ticket>> GetAll(TicketFilter filter);
        Result<List<Ticket>> GetAll(int pageNumber, int resultsPerPage);
        Task CreateManyAsync(List<Ticket> tickets);
        Result<List<Ticket>> GetAllSieve(SieveModel model);
    }
}
