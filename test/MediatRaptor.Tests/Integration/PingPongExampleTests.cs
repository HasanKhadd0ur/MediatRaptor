using FluentAssertions;
using MediatRaptor.CQRS.Commands;
using MediatRaptor.Mediator.Abstractions;
using MediatRaptor.Mediator.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace MediatRaptor.Tests.Integration
{
    public class PingPongExampleTests
    {
        public class PingCommand : ICommand<string>
        {
            public string Message { get; }

            public PingCommand(string message)
            {
                Message = message;
            }
        }
        public class PingCommandHandler : ICommandHandler<PingCommand, string>
        {
            private readonly IMediator _mediator;

            public PingCommandHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(PingCommand request, CancellationToken cancellationToken)
            {
                var response = $"Pong: {request.Message}";

                return response;
            }
        }
        private readonly IMediator _mediator;

        public PingPongExampleTests()
        {
            var services = new ServiceCollection();
            services.AddMediatRaptor(typeof(PingCommand).Assembly);
            _mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();
        }

        [Fact]
        public async Task Send_PingCommand_Should_Return_Pong()
        {
            var result = await _mediator.Send(new PingCommand("Hello Test!"));

            result.Should().Be("Pong: Hello Test!");
        }
    }
}
