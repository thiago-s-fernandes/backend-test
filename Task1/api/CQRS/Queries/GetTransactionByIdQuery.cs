using api.Models;
using api.Data;

namespace api.CQRS.Queries
{
  public class GetTransactionByIdQuery(string transactionId) : IQuery<Transaction?>
  {
    public string TransactionID { get; } = transactionId;
  }

  public class GetTransactionByIdQueryHandler(ITransactionRepository repository) : IQueryHandler<GetTransactionByIdQuery, Transaction?>
  {
    private readonly ITransactionRepository _repository = repository;

    public async Task<Transaction?> HandleAsync(GetTransactionByIdQuery query)
    {
      return await _repository.GetByIdAsync(query.TransactionID);
    }
  }
}
