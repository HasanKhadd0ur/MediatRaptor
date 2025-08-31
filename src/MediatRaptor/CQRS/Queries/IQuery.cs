using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.CQRS.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }

}
