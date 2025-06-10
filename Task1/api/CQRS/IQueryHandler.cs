namespace api.CQRS
{
  public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
  {
    Task<TResult> HandleAsync(TQuery query);
  }
}
