using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.CQRS.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }

}
