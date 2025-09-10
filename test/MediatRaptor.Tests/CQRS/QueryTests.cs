using FluentAssertions;
using MediatRaptor.CQRS.Queries;

namespace MediatRaptor.Tests.CQRS
{
    public class QueryTests
    {
        private record EchoQuery(string Message) : IQuery<string>;
        private class EchoHandler : IQueryHandler<EchoQuery, string>
        {
            public Task<string> Handle(EchoQuery query, CancellationToken cancellationToken) =>
                Task.FromResult(query.Message);
        }

        [Fact]
        public async Task QueryHandler_Should_Return_Message()
        {
            var handler = new EchoHandler();
            var result = await handler.Handle(new EchoQuery("Hi"), default);

            result.Should().Be("Hi");
        }
    }
}
