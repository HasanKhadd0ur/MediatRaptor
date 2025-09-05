namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Responsible for publishing notifications to multiple handlers.
    /// </summary>
    public interface IPublisher
    {
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification;
    }
}
