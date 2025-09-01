using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Examples.PingPongExample
{
    public class PingCommand : IRequest<string>
    {
        public string Message { get; }

        public PingCommand(string message)
        {
            Message = message;
        }
    }
}
