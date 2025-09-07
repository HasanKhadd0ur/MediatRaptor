using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.CQRS.Commands
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
                         where TCommand : ICommand<TResponse>
    {
    }
}
