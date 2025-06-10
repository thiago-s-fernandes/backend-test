using api.Data;
using api.Models;

namespace api.CQRS.Commands
{
  public class AddTransactionCommand(Transaction transaction) : ICommand<string>
  {
    public Transaction Transaction { get; } = transaction;
  }

  public class AddTransactionCommandHandler(ITransactionRepository repository) : ICommandHandler<AddTransactionCommand, string>
  {
    private readonly ITransactionRepository _repository = repository;

    public async Task<string> HandleAsync(AddTransactionCommand command)
    {
      // Generate a new transaction ID if not provided
      if (string.IsNullOrEmpty(command.Transaction.TransactionID))
      {
        command.Transaction.TransactionID = Guid.NewGuid().ToString();
      }

      return await _repository.AddAsync(command.Transaction);
    }
  }
}
