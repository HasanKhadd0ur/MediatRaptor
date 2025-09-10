namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Handler interface for requests with responses
    /// </summary>
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Handler interface for void commands
    /// </summary>
    public interface IRequestHandler<in TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest<Unit>
    { }

}
