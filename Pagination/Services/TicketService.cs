using Pagination.Models;
using Pagination.Models.Filters;
using Pagination.Services.Contracts;
using Sieve.Models;
using Sieve.Services;
using System.Linq.Expressions;

namespace Pagination.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext dbContext;
        private readonly ISieveProcessor sieveProcessor;
        public TicketService(AppDbContext appDbContext, ISieveProcessor sieveProcessor)
        {
            dbContext = appDbContext;
            this.sieveProcessor = sieveProcessor;
        }

        public Result<List<Ticket>> GetAll(TicketFilter filter)
        {
            IQueryable<Ticket> query = dbContext.Tickets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter.Category))
            {
                query = query.Where(prop => prop.Category!.Contains(filter.Category));
            }
            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                query = query.Where(prop => prop.Status!.Contains(filter.Status));
            }
            if (!string.IsNullOrWhiteSpace(filter.SortParam))
            {
                if (filter.SortOrder == "asc")
                {
                    query = query.OrderBy(GetSortProperty(filter.SortParam));
                }
                else
                {
                    query = query.OrderByDescending(GetSortProperty(filter.SortParam));
                }
            }
            List<Ticket> data = query.Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize).ToList();

            return new Result<List<Ticket>>(data, new PageInfo(filter.PageNumber, filter.PageSize, dbContext.Tickets.Count()));
        }

        public Result<List<Ticket>> GetAll(int pageNumber, int pageSize)
        {
            IQueryable<Ticket> query = dbContext.Tickets.AsQueryable();
            List<Ticket> data = dbContext.Tickets.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            return new Result<List<Ticket>>(data, new PageInfo(pageNumber, pageSize, dbContext.Tickets.Count()));
        }

        public async Task CreateManyAsync(List<Ticket> tickets)
        {
            await dbContext.Tickets.AddRangeAsync(tickets);
            await dbContext.SaveChangesAsync();
        }

        private static Expression<Func<Ticket, object>> GetSortProperty(string sortColumn) =>
             sortColumn.ToLower() switch
             {
                 "category" => ticket => ticket.Category,
                 "status" => ticket => ticket.Status,
                 _ => ticket => ticket.Id,
             };

        // Sieve Filter
        public Result<List<Ticket>> GetAllSieve(SieveModel model)
        {
            IQueryable<Ticket> query = dbContext.Tickets.AsQueryable();
            query = sieveProcessor.Apply(model, query);
            return new Result<List<Ticket>>(query.ToList(), new PageInfo(model.Page??default, model.PageSize??default, dbContext.Tickets.Count()));
        }
    }
}
