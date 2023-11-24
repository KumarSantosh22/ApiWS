using Stripe;
using Stripe2Pay.Models;

namespace Stripe2Pay.Services.Contracts
{
    public interface IStripeService
    {
        Task<JSIntent> CreatePaymentIntent(long amount);
        //Task<PaymentIntent> CreatePaymentIntent(long amount);
    }
}