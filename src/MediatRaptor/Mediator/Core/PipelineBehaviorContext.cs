namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// Optional context holder for pipeline executions. Reserved for future extension.
    /// </summary>
    public sealed class PipelineBehaviorContext
    {
        public CancellationToken CancellationToken { get; }

        public PipelineBehaviorContext(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }
        // Add fields/properties later if you need metadata flowing through pipeline.
    }
}
