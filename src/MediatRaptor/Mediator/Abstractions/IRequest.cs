namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Represents a request that produces a response when handled.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IRequest<TResponse>
    {
    }
    /// <summary>
    /// Represents a request that does not return a response.
    /// Use <see cref="Unit"/> as the return type when no data is expected.
    /// </summary>
    public interface IRequest : IRequest<Unit>
    {
    }
}
