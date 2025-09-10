namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Responsible for sending requests and returning responses.
    /// </summary>
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
