using Microsoft.AspNetCore.Mvc;
using Pagination.Services.Contracts;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITicketDapperService ticketDapperService;
        public TestsController(ITicketDapperService ticketDapperService)
        {
            this.ticketDapperService = ticketDapperService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllSync()
        {
            var result = await ticketDapperService.GetAllAsync();
            return Ok(result);
        }
    }
}
