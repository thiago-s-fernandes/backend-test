using api.Data;
using api.Models;

namespace api.CQRS.Queries
{
  public class GetAllTransactionsQuery : IQuery<IEnumerable<Transaction>>
  {
  }

  public class GetAllTransactionsQueryHandler(ITransactionRepository repository) : IQueryHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
  {
    private readonly ITransactionRepository _repository = repository;

    public async Task<IEnumerable<Transaction>> HandleAsync(GetAllTransactionsQuery query)
    {
      return await _repository.GetAllAsync();
    }
  }
}
