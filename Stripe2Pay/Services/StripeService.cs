using Stripe2Pay.Services.Contracts;
using Stripe;
using Stripe2Pay.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Stripe2Pay.Services
{
    public class StripeService : IStripeService
    {
        public StripeService()
        {
        }

        public async Task<JSIntent> CreatePaymentIntent(long amount)
        {
            // Creating Customer
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Email = "santosh.k@technovert.com",
                Name = "Santosh Kumar",
                Phone = "8700004930",
                Address = new AddressOptions { City = "Hyderabad", State = "TS", Country = "India", PostalCode = "50003", Line1 = "", Line2 = "" }
            };
            CustomerService service = new CustomerService();
            Customer customer = await service.CreateAsync(customerOptions);

            // Creating Payment Intent
            PaymentIntentCreateOptions paymentIntentCreateOptions = new PaymentIntentCreateOptions
            {
                Amount = 2000,
                Currency = "inr",
                ReceiptEmail = "santosh.k@technovert.com",
                Customer = customer.Id,
                Description = "Payment Intent Ccreated",
                PaymentMethodTypes = new List<string>
                { 
                    "card"
                }
            };
            PaymentIntentService paymentIntentService = new PaymentIntentService();
            PaymentIntent intent =  await paymentIntentService.CreateAsync(paymentIntentCreateOptions);
            Console.WriteLine($"Secret: {intent.ClientSecret}");
            return JsonConvert.DeserializeObject<JSIntent>(intent.StripeResponse.Content);
        }
    }
}
