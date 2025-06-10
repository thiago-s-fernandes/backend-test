using api.CQRS.Commands;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.CQRS.Queries;
using api.CQRS;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TransactionsController(
      IQueryHandler<GetAllTransactionsQuery, IEnumerable<Transaction>> getAllHandler,
      IQueryHandler<GetTransactionByIdQuery, Transaction?> getByIdHandler,
      ICommandHandler<AddTransactionCommand, string> addHandler,
      ICommandHandler<UpdateTransactionCommand, bool> updateHandler,
      ICommandHandler<DeleteTransactionCommand, bool> deleteHandler) : ControllerBase
  {
    private readonly IQueryHandler<GetAllTransactionsQuery, IEnumerable<Transaction>> _getAllHandler = getAllHandler;
    private readonly IQueryHandler<GetTransactionByIdQuery, Transaction?> _getByIdHandler = getByIdHandler;
    private readonly ICommandHandler<AddTransactionCommand, string> _addHandler = addHandler;
    private readonly ICommandHandler<UpdateTransactionCommand, bool> _updateHandler = updateHandler;
    private readonly ICommandHandler<DeleteTransactionCommand, bool> _deleteHandler = deleteHandler;

    // GET: api/transactions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
    {
      var query = new GetAllTransactionsQuery();
      var transactions = await _getAllHandler.HandleAsync(query);
      return Ok(transactions);
    }

    // GET: api/transactions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Transaction>> GetTransactionById(string id)
    {
      var query = new GetTransactionByIdQuery(id);
      var transaction = await _getByIdHandler.HandleAsync(query);

      if (transaction == null)
      {
        return NotFound($"Transaction with ID {id} not found.");
      }

      return Ok(transaction);
    }

    // POST: api/transactions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> AddTransaction([FromBody] Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var command = new AddTransactionCommand(transaction);
      var transactionId = await _addHandler.HandleAsync(command);

      return CreatedAtAction(nameof(GetTransactionById), new { id = transactionId }, transactionId);
    }

    // PUT: api/transactions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTransaction(string id, [FromBody] Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != transaction.TransactionID)
      {
        return BadRequest("Transaction ID in the URL does not match the ID in the request body.");
      }

      var command = new UpdateTransactionCommand(transaction);
      var result = await _updateHandler.HandleAsync(command);

      if (!result)
      {
        return NotFound($"Transaction with ID {id} not found.");
      }

      return NoContent();
    }

    // DELETE: api/transactions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTransaction(string id)
    {
      var command = new DeleteTransactionCommand(id);
      var result = await _deleteHandler.HandleAsync(command);

      if (!result)
      {
        return NotFound($"Transaction with ID {id} not found.");
      }

      return NoContent();
    }
  }
}
