using api.Data;

namespace api.CQRS.Commands
{
  public class DeleteTransactionCommand(string transactionId) : ICommand<bool>
  {
    public string TransactionID { get; } = transactionId;
  }

  public class DeleteTransactionCommandHandler(ITransactionRepository repository) : ICommandHandler<DeleteTransactionCommand, bool>
  {
    private readonly ITransactionRepository _repository = repository;

    public async Task<bool> HandleAsync(DeleteTransactionCommand command)
    {
      return await _repository.DeleteAsync(command.TransactionID);
    }
  }
}
