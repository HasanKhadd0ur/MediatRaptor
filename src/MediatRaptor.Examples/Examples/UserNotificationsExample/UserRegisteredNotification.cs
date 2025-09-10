using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Examples.Notifications
{
    public class UserRegisteredNotification : INotification
    {
        public string UserId { get; }
        public string Email { get; }

        public UserRegisteredNotification(string userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}