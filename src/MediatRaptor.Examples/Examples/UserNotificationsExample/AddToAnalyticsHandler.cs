using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Notifications
{
    public class AddToAnalyticsHandler : INotificationHandler<UserRegisteredNotification>
    {
        public Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"📊 Adding user {notification.UserId} to analytics system");
            return Task.CompletedTask;
        }
    }

}
