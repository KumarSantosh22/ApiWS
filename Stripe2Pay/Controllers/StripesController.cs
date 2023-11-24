using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe2Pay.Models;
using Stripe2Pay.Services.Contracts;

namespace Stripe2Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripesController : ControllerBase
    {
        private readonly IStripeService _stripeService;
        public StripesController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<JSIntent>> CreatePaymentIntent([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                JSIntent intent = await _stripeService.CreatePaymentIntent(paymentRequest.Amount);
                return Ok(intent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
