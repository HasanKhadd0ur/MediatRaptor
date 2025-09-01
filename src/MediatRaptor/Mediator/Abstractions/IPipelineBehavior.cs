namespace MediatRaptor.Mediator.Abstractions
{
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

    /// <summary>
    /// Pipeline behavior that wraps request handling.
    /// </summary>
    public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}
