using Xunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MediatRaptor.Mediator.Abstractions;
using MediatRaptor.Mediator.Core;
using System.Threading.Tasks;

namespace MediatRaptor.Tests.Notifications
{
    public class NotificationTests
    {
        public class TestNotification : INotification { public string Message { get; set; } = ""; }
        public class TestHandler : INotificationHandler<TestNotification>
        {
            public static bool WasCalled;
            public Task Handle(TestNotification notification, CancellationToken cancellationToken)
            {
                WasCalled = true;
                return Task.CompletedTask;
            }
        }

        [Fact]
        public async Task Publish_Should_Invoke_All_Handlers()
        {
            var services = new ServiceCollection();
            services.AddMediatRaptor(typeof(NotificationTests).Assembly);
            var mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();

            await mediator.Publish(new TestNotification { Message = "Ping" });

            TestHandler.WasCalled.Should().BeTrue();
        }
    }
}
