namespace MediatRaptor.CQRS.Commands
{
    public interface ILoggableCommand<out TResponse> : ICommand<TResponse>
    {
    }
}
