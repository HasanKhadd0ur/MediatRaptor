using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// Default mediator implementation (constructor-based DI)
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new InvalidOperationException($"No handler found for request type {request.GetType().Name}");

            return await (Task<TResponse>)handlerType
                .GetMethod("Handle")!
                .Invoke(handler, new object[] { request, cancellationToken })!;
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));

            var handlerType = typeof(IEnumerable<>).MakeGenericType(typeof(INotificationHandler<>).MakeGenericType(notification.GetType()));
            var handlers = (IEnumerable<object>)_serviceProvider.GetService(handlerType)! ?? Enumerable.Empty<object>();

            foreach (var handler in handlers)
            {
                var method = handler.GetType().GetMethod("Handle")!;
                await (Task)method.Invoke(handler, new object[] { notification, cancellationToken })!;
            }
        }
    }
    /// <summary>
    /// DI factory used by the Mediator to resolve handlers & behaviors.
    /// Compatible with constructors taking Func<Type, object?> or equivalent.
    /// </summary>
    public delegate object? ServiceFactory(Type serviceType);

}
