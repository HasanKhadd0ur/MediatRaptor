using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using MediatRaptor.Mediator.Abstractions;
using MediatRaptor.Mediator.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRaptor.Tests.Mediator
{
    public class MediatorTests
    {
        public record TestRequest(string Input) : IRequest<string>;
        public class TestHandler : IRequestHandler<TestRequest, string>
        {
            public Task<string> Handle(TestRequest request, CancellationToken cancellationToken) =>
                Task.FromResult($"Handled: {request.Input}");
        }

        [Fact]
        public async Task Send_Should_Invoke_Handler()
        {
            var services = new ServiceCollection();
            services.AddMediatRaptor(typeof(MediatorTests).Assembly);

            var mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();

            var response = await mediator.Send(new TestRequest("Ping"));

            response.Should().Be("Handled: Ping");
        }

        [Fact]
        public async Task Send_Should_Throw_When_No_Handler()
        {
            var services = new ServiceCollection();
            services.AddMediatRaptor(); // no handlers
            var mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();

            var act = async () => await mediator.Send(new TestRequest("Ping"));

            await act.Should().ThrowAsync<HandlerNotFoundException>();
        }
    }
}
