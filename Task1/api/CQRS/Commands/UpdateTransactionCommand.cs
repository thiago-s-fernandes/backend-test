using api.Data;
using api.Models;

namespace api.CQRS.Commands
{
  public class UpdateTransactionCommand(Transaction transaction) : ICommand<bool>
  {
    public Transaction Transaction { get; } = transaction;
  }

  public class UpdateTransactionCommandHandler(ITransactionRepository repository) : ICommandHandler<UpdateTransactionCommand, bool>
  {
    private readonly ITransactionRepository _repository = repository;

    public async Task<bool> HandleAsync(UpdateTransactionCommand command)
    {
      return await _repository.UpdateAsync(command.Transaction);
    }
  }
}
