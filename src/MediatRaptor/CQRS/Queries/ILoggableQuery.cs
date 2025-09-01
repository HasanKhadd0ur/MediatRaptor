namespace MediatRaptor.CQRS.Queries
{
    public interface ILoggableQuery<out TResponse> : IQuery<TResponse>
    {
    }

}
