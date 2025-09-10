using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Notifications
{
    public class SendWelcomeEmailHandler : INotificationHandler<UserRegisteredNotification>
    {
        public Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"📧 Sending welcome email to {notification.Email}");
            return Task.CompletedTask;
        }
    }

}
