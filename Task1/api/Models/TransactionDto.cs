namespace api.Models
{
  public class TransactionDto
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
    public required int IsProxyIP { get; set; }
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

    // Método para converter para Transaction
    public Transaction ToTransaction()
    {
      return new Transaction
      {
        AccountID = this.AccountID,
        TransactionID = this.TransactionID,
        TransactionAmount = this.TransactionAmount,
        TransactionCurrencyCode = this.TransactionCurrencyCode,
        LocalHour = this.LocalHour,
        TransactionScenario = this.TransactionScenario,
        TransactionType = this.TransactionType,
        TransactionIPaddress = this.TransactionIPaddress,
        IpState = this.IpState,
        IpPostalCode = this.IpPostalCode,
        IpCountry = this.IpCountry,
        IsProxyIP = this.IsProxyIP == 1, // Converter int para boolean
        BrowserLanguage = this.BrowserLanguage,
        PaymentInstrumentType = this.PaymentInstrumentType,
        CardType = this.CardType,
        PaymentBillingPostalCode = this.PaymentBillingPostalCode,
        PaymentBillingState = this.PaymentBillingState,
        PaymentBillingCountryCode = this.PaymentBillingCountryCode,
        ShippingPostalCode = this.ShippingPostalCode,
        ShippingState = this.ShippingState,
        ShippingCountry = this.ShippingCountry,
        CvvVerifyResult = this.CvvVerifyResult,
        DigitalItemCount = this.DigitalItemCount,
        PhysicalItemCount = this.PhysicalItemCount,
        TransactionDateTime = this.TransactionDateTime
      };
    }

    // Método estático para converter de Transaction
    public static TransactionDto FromTransaction(Transaction transaction)
    {
      return new TransactionDto
      {
        AccountID = transaction.AccountID,
        TransactionID = transaction.TransactionID,
        TransactionAmount = transaction.TransactionAmount,
        TransactionCurrencyCode = transaction.TransactionCurrencyCode,
        LocalHour = transaction.LocalHour,
        TransactionScenario = transaction.TransactionScenario,
        TransactionType = transaction.TransactionType,
        TransactionIPaddress = transaction.TransactionIPaddress,
        IpState = transaction.IpState,
        IpPostalCode = transaction.IpPostalCode,
        IpCountry = transaction.IpCountry,
        IsProxyIP = transaction.IsProxyIP ? 1 : 0, // Converter boolean para int
        BrowserLanguage = transaction.BrowserLanguage,
        PaymentInstrumentType = transaction.PaymentInstrumentType,
        CardType = transaction.CardType,
        PaymentBillingPostalCode = transaction.PaymentBillingPostalCode,
        PaymentBillingState = transaction.PaymentBillingState,
        PaymentBillingCountryCode = transaction.PaymentBillingCountryCode,
        ShippingPostalCode = transaction.ShippingPostalCode,
        ShippingState = transaction.ShippingState,
        ShippingCountry = transaction.ShippingCountry,
        CvvVerifyResult = transaction.CvvVerifyResult,
        DigitalItemCount = transaction.DigitalItemCount,
        PhysicalItemCount = transaction.PhysicalItemCount,
        TransactionDateTime = transaction.TransactionDateTime
      };
    }
  }
}
