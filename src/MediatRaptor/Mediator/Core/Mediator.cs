using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// Default mediator implementation (constructor-based DI)
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly ServiceFactory _serviceFactory;

        public Mediator(ServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory ?? throw new ArgumentNullException(nameof(serviceFactory));
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

            // Resolve the correct closed generic handler
            var handler = _serviceFactory(handlerType);
            if (handler == null)
                throw new HandlerNotFoundException(requestType);

            // Resolve pipeline behaviors for this exact request/response pair
            var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType, typeof(TResponse));
            var behaviors = ((IEnumerable<object>?)_serviceFactory(typeof(IEnumerable<>).MakeGenericType(behaviorType)))
                ?.Cast<dynamic>()
                .ToList() ?? new List<dynamic>();

            // Build handler delegate
            RequestHandlerDelegate<TResponse> handlerDelegate =
                () => ((dynamic)handler).Handle((dynamic)request, cancellationToken);

            // Wrap with pipeline behaviors (last one closest to handler)
            foreach (var behavior in behaviors.AsEnumerable().Reverse())
            {
                var next = handlerDelegate;
                handlerDelegate = () => behavior.Handle((dynamic)request, cancellationToken, next);
            }

            return await handlerDelegate();
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));

            var handlers = _serviceFactory.GetInstances<INotificationHandler<TNotification>>(typeof(TNotification)).ToList();

            foreach (var handler in handlers)
                await handler.Handle(notification, cancellationToken);
        }

        
        
    }

}
