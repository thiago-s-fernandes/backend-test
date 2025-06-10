using Dapper;
using System.Data;
using api.Models;

namespace api.Data
{
  public class TransactionRepository(IDbConnection dbConnection) : ITransactionRepository
  {
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
      const string sql = @"
                SELECT
                    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
                    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
                    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
                    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
                    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
                    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
                    PhysicalItemCount, TransactionDateTime
                FROM Transactions";

      var transactions = await _dbConnection.QueryAsync<Transaction>(sql);

      return transactions.Select(t =>
      {
        return t;
      });
    }

    public async Task<Transaction?> GetByIdAsync(string id)
    {
      const string sql = @"
                SELECT
                    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
                    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
                    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
                    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
                    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
                    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
                    PhysicalItemCount, TransactionDateTime
                FROM Transactions
                WHERE TransactionID = :TransactionID";

      var parameters = new { TransactionID = id };
      return await _dbConnection.QueryFirstOrDefaultAsync<Transaction>(sql, parameters);
    }

    public async Task<string> AddAsync(Transaction transaction)
    {
      const string sql = @"
                INSERT INTO Transactions (
                    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
                    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
                    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
                    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
                    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
                    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
                    PhysicalItemCount, TransactionDateTime
                ) VALUES (
                    :AccountID, :TransactionID, :TransactionAmount, :TransactionCurrencyCode,
                    :LocalHour, :TransactionScenario, :TransactionType, :TransactionIPaddress,
                    :IpState, :IpPostalCode, :IpCountry, :IsProxyIP, :BrowserLanguage,
                    :PaymentInstrumentType, :CardType, :PaymentBillingPostalCode,
                    :PaymentBillingState, :PaymentBillingCountryCode, :ShippingPostalCode,
                    :ShippingState, :ShippingCountry, :CvvVerifyResult, :DigitalItemCount,
                    :PhysicalItemCount, :TransactionDateTime
                )";

      var parameters = new
      {
        transaction.AccountID,
        transaction.TransactionID,
        transaction.TransactionAmount,
        transaction.TransactionCurrencyCode,
        transaction.LocalHour,
        transaction.TransactionScenario,
        transaction.TransactionType,
        transaction.TransactionIPaddress,
        transaction.IpState,
        transaction.IpPostalCode,
        transaction.IpCountry,
        IsProxyIP = transaction.IsProxyIP ? 1 : 0,
        transaction.BrowserLanguage,
        transaction.PaymentInstrumentType,
        transaction.CardType,
        transaction.PaymentBillingPostalCode,
        transaction.PaymentBillingState,
        transaction.PaymentBillingCountryCode,
        transaction.ShippingPostalCode,
        transaction.ShippingState,
        transaction.ShippingCountry,
        transaction.CvvVerifyResult,
        transaction.DigitalItemCount,
        transaction.PhysicalItemCount,
        transaction.TransactionDateTime
      };

      await _dbConnection.ExecuteAsync(sql, parameters);
      return transaction.TransactionID;
    }

    public async Task<bool> UpdateAsync(Transaction transaction)
    {
      const string sql = @"
                UPDATE Transactions SET
                    AccountID = :AccountID,
                    TransactionAmount = :TransactionAmount,
                    TransactionCurrencyCode = :TransactionCurrencyCode,
                    LocalHour = :LocalHour,
                    TransactionScenario = :TransactionScenario,
                    TransactionType = :TransactionType,
                    TransactionIPaddress = :TransactionIPaddress,
                    IpState = :IpState,
                    IpPostalCode = :IpPostalCode,
                    IpCountry = :IpCountry,
                    IsProxyIP = :IsProxyIP,
                    BrowserLanguage = :BrowserLanguage,
                    PaymentInstrumentType = :PaymentInstrumentType,
                    CardType = :CardType,
                    PaymentBillingPostalCode = :PaymentBillingPostalCode,
                    PaymentBillingState = :PaymentBillingState,
                    PaymentBillingCountryCode = :PaymentBillingCountryCode,
                    ShippingPostalCode = :ShippingPostalCode,
                    ShippingState = :ShippingState,
                    ShippingCountry = :ShippingCountry,
                    CvvVerifyResult = :CvvVerifyResult,
                    DigitalItemCount = :DigitalItemCount,
                    PhysicalItemCount = :PhysicalItemCount,
                    TransactionDateTime = :TransactionDateTime
                WHERE TransactionID = :TransactionID";

      var parameters = new
      {
        transaction.AccountID,
        transaction.TransactionID,
        transaction.TransactionAmount,
        transaction.TransactionCurrencyCode,
        transaction.LocalHour,
        transaction.TransactionScenario,
        transaction.TransactionType,
        transaction.TransactionIPaddress,
        transaction.IpState,
        transaction.IpPostalCode,
        transaction.IpCountry,
        IsProxyIP = transaction.IsProxyIP ? 1 : 0,
        transaction.BrowserLanguage,
        transaction.PaymentInstrumentType,
        transaction.CardType,
        transaction.PaymentBillingPostalCode,
        transaction.PaymentBillingState,
        transaction.PaymentBillingCountryCode,
        transaction.ShippingPostalCode,
        transaction.ShippingState,
        transaction.ShippingCountry,
        transaction.CvvVerifyResult,
        transaction.DigitalItemCount,
        transaction.PhysicalItemCount,
        transaction.TransactionDateTime
      };

      var affectedRows = await _dbConnection.ExecuteAsync(sql, parameters);
      return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
      const string sql = "DELETE FROM Transactions WHERE TransactionID = :TransactionID";
      var parameters = new { TransactionID = id };
      var affectedRows = await _dbConnection.ExecuteAsync(sql, parameters);
      return affectedRows > 0;
    }
  }
}
