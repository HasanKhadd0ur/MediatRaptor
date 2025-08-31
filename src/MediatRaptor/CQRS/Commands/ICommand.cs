
using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.CQRS.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
    
}
