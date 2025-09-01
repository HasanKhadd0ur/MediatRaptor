namespace MediatRaptor.Mediator.Core
{
    public sealed class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(Type requestType)
        : base($"No handler registered for request type '{requestType?.FullName}'")
        {
        }
    }
}
