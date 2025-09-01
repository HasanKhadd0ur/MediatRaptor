using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Examples.PingPongExample
{
    public class PingCommandHandler : IRequestHandler<PingCommand, string>
    {
        private readonly IMediator _mediator;

        public PingCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            var response = $"Pong received your message: {request.Message}";

            return response;
        }
    }
}
