using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Notifications
{
    public class NotificationDemo
    {
        private readonly IMediator _mediator;

        public NotificationDemo(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Run()
        {
            var notification = new UserRegisteredNotification("u123", "user@example.com");
            await _mediator.Publish(notification);
        }
    }
}