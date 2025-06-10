using api.Models;

namespace api.Data
{
  public interface ITransactionRepository
  {
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task<Transaction?> GetByIdAsync(string id);
    Task<string> AddAsync(Transaction transaction);
    Task<bool> UpdateAsync(Transaction transaction);
    Task<bool> DeleteAsync(string id);
  }
}
