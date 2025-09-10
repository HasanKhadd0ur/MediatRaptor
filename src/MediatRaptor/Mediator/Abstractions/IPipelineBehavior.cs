namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Pipeline behavior that wraps request handling.
    /// </summary>
    public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

}
