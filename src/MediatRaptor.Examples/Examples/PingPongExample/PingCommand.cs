using MediatRaptor.CQRS.Commands;

namespace MediatRaptor.Examples.Examples.PingPongExample
{
    public class PingCommand : ICommand<string>
    {
        public string Message { get; }

        public PingCommand(string message)
        {
            Message = message;
        }
    }
}
