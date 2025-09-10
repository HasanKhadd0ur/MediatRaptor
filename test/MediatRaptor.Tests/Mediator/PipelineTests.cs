using Xunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MediatRaptor.Mediator.Abstractions;
using MediatRaptor.Mediator.Core;
using System.Threading.Tasks;

namespace MediatRaptor.Tests.Mediator
{
    public class PipelineTests
    {
        public record TestRequest(string Input) : IRequest<string>;
        public class TestHandler : IRequestHandler<TestRequest, string>
        {
            public Task<string> Handle(TestRequest request, CancellationToken cancellationToken) =>
                Task.FromResult(request.Input);
        }

        public class UppercaseBehavior : IPipelineBehavior<TestRequest, string>
        {
            public async Task<string> Handle(TestRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<string> next)
            {
                var response = await next();
                return response.ToUpper();
            }
        }

        [Fact]
        public async Task Pipeline_Should_Execute_Behavior()
        {
            var services = new ServiceCollection();
            services.AddMediatRaptor(typeof(PipelineTests).Assembly);
            services.AddScoped<IPipelineBehavior<TestRequest, string>, UppercaseBehavior>();

            var mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();

            var result = await mediator.Send(new TestRequest("hello"));

            result.Should().Be("HELLO");
        }
    }
}
