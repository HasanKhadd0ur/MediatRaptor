using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Mediator.Core
{
    // Executor lives in Core.Mediator currently; keep this helper for potential reuse.
    internal class PipelineBehaviorExecutor<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IPipelineBehavior<TRequest, TResponse>> _behaviors;
        private readonly RequestHandlerDelegate<TResponse> _handler;

        public PipelineBehaviorExecutor(IEnumerable<IPipelineBehavior<TRequest, TResponse>> behaviors, RequestHandlerDelegate<TResponse> handler)
        {
            _behaviors = behaviors ?? Enumerable.Empty<IPipelineBehavior<TRequest, TResponse>>();
            _handler = handler;
        }

        public Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken)
        {
            RequestHandlerDelegate<TResponse> next = _handler;

            foreach (var behavior in _behaviors.Reverse())
            {
                var current = next;
                next = () => behavior.Handle(request, cancellationToken, current);
            }

            return next();
        }
    }
}
