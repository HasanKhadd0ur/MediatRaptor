using FluentAssertions;
using MediatRaptor.CQRS.Commands;
using System.Threading.Tasks;
using Xunit;

namespace MediatRaptor.Tests.CQRS
{
    public class CommandTests
    {
        private record AddCommand(int A, int B) : ICommand<int>;
        private class AddHandler : ICommandHandler<AddCommand, int>
        {
            public Task<int> Handle(AddCommand command, CancellationToken cancellationToken) =>
                Task.FromResult(command.A + command.B);
        }

        [Fact]
        public async Task CommandHandler_Should_Return_Sum()
        {
            var handler = new AddHandler();
            var result = await handler.Handle(new AddCommand(2, 3), default);

            result.Should().Be(5);
        }
    }
}
