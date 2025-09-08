namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Notification handler interface
    /// </summary>
    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
