using MediatRaptor.Mediator.Abstractions;

namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// A no-op pipeline behavior useful as a fallback.
    /// </summary>
    public sealed class DefaultPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        => next();
    }
}
