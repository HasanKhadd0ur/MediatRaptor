namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// Optional context holder for pipeline executions. Reserved for future extension.
    /// </summary>
    public sealed class PipelineBehaviorContext
    {
        public Guid CorrelationId { get; }
        public DateTime Timestamp { get; }
        public Type RequestType { get; }
        public object Request { get; }
        public CancellationToken CancellationToken { get; }

        // Add fields/properties later if you need metadata flowing through pipeline.

        public IDictionary<string, object> Items { get; } = new Dictionary<string, object>();

        public PipelineBehaviorContext(object request, CancellationToken cancellationToken)
        {
            CorrelationId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
            RequestType = request.GetType();
            Request = request;
            CancellationToken = cancellationToken;
        }
    }
}
