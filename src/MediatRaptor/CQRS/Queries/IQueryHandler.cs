using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.CQRS.Queries
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    {
    }
}
