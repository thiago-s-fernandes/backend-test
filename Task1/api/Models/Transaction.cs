namespace api.Models
{
  public class Transaction
  {
    public required string AccountID { get; set; }
    public required string TransactionID { get; set; }
    public required decimal TransactionAmount { get; set; }
    public required string TransactionCurrencyCode { get; set; }
    public required int LocalHour { get; set; }
    public required string TransactionScenario { get; set; }
    public required string TransactionType { get; set; }
    public required string TransactionIPaddress { get; set; }
    public required string IpState { get; set; }
    public required string IpPostalCode { get; set; }
    public required string IpCountry { get; set; }
    public required bool IsProxyIP { get; set; }
    public required string BrowserLanguage { get; set; }
    public required string PaymentInstrumentType { get; set; }
    public required string CardType { get; set; }
    public required string PaymentBillingPostalCode { get; set; }
    public required string PaymentBillingState { get; set; }
    public required string PaymentBillingCountryCode { get; set; }
    public required string ShippingPostalCode { get; set; }
    public required string ShippingState { get; set; }
    public required string ShippingCountry { get; set; }
    public required string CvvVerifyResult { get; set; }
    public required int DigitalItemCount { get; set; }
    public required int PhysicalItemCount { get; set; }
    public required DateTime TransactionDateTime { get; set; }
  }
}
