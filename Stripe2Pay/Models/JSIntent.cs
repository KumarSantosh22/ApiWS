namespace Stripe2Pay.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AmountDetails
    {
        public Tip tip { get; set; }
    }

    public class Card
    {
        public object installments { get; set; }
        public object mandate_options { get; set; }
        public object network { get; set; }
        public string request_three_d_secure { get; set; }
    }

    public class Metadata
    {
    }

    public class PaymentMethodOptions
    {
        public Card card { get; set; }
    }

    public class JSIntent
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int amount { get; set; }
        public int amount_capturable { get; set; }
        public AmountDetails amount_details { get; set; }
        public int amount_received { get; set; }
        public object application { get; set; }
        public object application_fee_amount { get; set; }
        public object automatic_payment_methods { get; set; }
        public object canceled_at { get; set; }
        public object cancellation_reason { get; set; }
        public string capture_method { get; set; }
        public string client_secret { get; set; }
        public string confirmation_method { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public object customer { get; set; }
        public object description { get; set; }
        public object invoice { get; set; }
        public object last_payment_error { get; set; }
        public object latest_charge { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public object next_action { get; set; }
        public object on_behalf_of { get; set; }
        public object payment_method { get; set; }
        public object payment_method_configuration_details { get; set; }
        public PaymentMethodOptions payment_method_options { get; set; }
        public List<string> payment_method_types { get; set; }
        public object processing { get; set; }
        public object receipt_email { get; set; }
        public object review { get; set; }
        public object setup_future_usage { get; set; }
        public object shipping { get; set; }
        public object source { get; set; }
        public object statement_descriptor { get; set; }
        public object statement_descriptor_suffix { get; set; }
        public string status { get; set; }
        public object transfer_data { get; set; }
        public object transfer_group { get; set; }
    }

    public class Tip
    {
    }


}
