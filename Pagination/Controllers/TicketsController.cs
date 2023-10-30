using Microsoft.AspNetCore.Mvc;
using Pagination.Models;
using Pagination.Models.Filters;
using Pagination.Services.Contracts;
using Sieve.Models;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService service;
        public TicketsController(ITicketService service)
        {
            this.service = service;
        }

        // GET: api/<ServiceRequestsController>
        [HttpPost("[action]")]
        public ActionResult<APIResponse<List<Ticket>>> GetAll([FromBody] TicketFilter filter)
        {
            Result<List<Ticket>> tickets = service.GetAll(filter);
            return Ok(APIResponse<List<Ticket>>.Success(tickets.Data, tickets.PageInfo));
        }

        //public ActionResult<APIResponse<List<Ticket>>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        //{
        //    Result<List<Ticket>> tickets = service.GetAll(pageNumber, pageSize);
        //    return Ok(APIResponse<List<Ticket>>.Success(tickets.Data, tickets.PageInfo));
        //}

        [HttpPost]
        public async Task<ActionResult<APIResponse<List<Ticket>>>> Post()
        {
            string[] statuses = { "Started", "Processed", "Pending", "Closed" };
            List<Ticket> tickets = new();
            for (int i = 0; i < 1000; i++)
            {
                tickets.Add(new Ticket($"Category{i % 9}", statuses[i % 4]));
            }
            //await service.CreateManyAsync(tickets);
            return Ok(APIResponse<List<Ticket>>.Success(default, default));
        }

        [HttpGet("[action]")]
        public ActionResult<APIResponse<List<Ticket>>> GetAllSieve([FromQuery] SieveModel model)
        {
            Result<List<Ticket>> result = service.GetAllSieve(model);
            return Ok(APIResponse<List<Ticket>>.Success(result.Data, result.PageInfo));
        }
    }
}
