using Pagination.Data.Contracts;
using Pagination.Models;
using Pagination.Services.Contracts;

namespace Pagination.Services
{
    public class TicketDapperService : ITicketDapperService
    {
        private readonly IRepositoryDapper<Ticket> repository;

        public TicketDapperService(IRepositoryDapper<Ticket> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await this.repository.GetAllAsync("Select * from bnsi.\"Ticket\";\r\n");
        }
    }
}
